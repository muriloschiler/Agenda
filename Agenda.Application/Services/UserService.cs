using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.Interfaces.Services;
using Agenda.Application.ViewModels.User;
using Agenda.Domain.Domain;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IUnityOfWork _unityOfWork { get; set; }

        public UserService(IUserRepository userRepository, IMapper mapper,IUnityOfWork unityOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unityOfWork=unityOfWork;

            _userRepository.AddPreQuery(query => query.Include(us=>us.UserRole));
        }

        public async Task<UserResponse> GetById(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            if(user is null)
                user = new User{
                    Name = "Exemplo vazio"
                };
            return _mapper.Map<User,UserResponse>(user);
        }
    }
}