using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.Interfaces.Services;
using Agenda.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    public class UserController: ControllerBase
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService=userService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserResponse>> GetById(int id){
            return Ok(await _userService.GetById(id));
        }
        
    }
}