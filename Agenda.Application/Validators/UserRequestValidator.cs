using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.ViewModels.User;
using Agenda.Domain.Core;
using Agenda.Domain.Domain.Enumerations;
using Agenda.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Application.Validators
{
    public class UserRequestValidator: AbstractValidator<UserRequest>
    {
        public IUserRepository _userRepository { get; set; }

        public UserRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(ur => ur.Name)
                .NotEmpty();
                                
            RuleFor(ur => ur.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(ur => ur.Username)
                .NotEmpty();
            
            RuleFor(ur => ur.Password)
                .MinimumLength(3)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(ur => ur.Email)
                .MustAsync(async (email, cancelToken) => ! await EmailAreadyInDataBase(email))
                .WithMessage("Já existe um usuário com e-mail informado.");
                
            RuleFor(ur => ur.Username)
                .MustAsync((username, cancelToken) => userRepository.Query().AsNoTracking().AllAsync(us => us.Username != username, cancelToken))
                .WithMessage("Já existe um usuário com username informado.");

            RuleFor(ur => ur.UserRoleId)
                 .Must(type => Enumeration.GetAll<UserRole>().Any(userRole => userRole.Id == type))
                 .WithMessage("Tipo de usuario invalido");
        }

        private async Task<bool> EmailAreadyInDataBase(string email)
        {
            return await _userRepository
                .Query()
                .AnyAsync(us => us.Email == email);
        }
    }
}