using AutoMapper;
using DatingApp.Data;
using DatingApp.DTO;
using DatingApp.Entities;
using DatingApp.Interfaces.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
 //   [Authorize]
    public class UsersController :BaseApiController
    {
       
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly DataContext context;

        public UsersController(IUserRepository userRepository, IMapper mapper, DataContext context)
        {
        
            this._userRepository = userRepository;
            this._mapper = mapper;
            this.context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersToRetune = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToRetune);
        }
        [HttpGet("users1")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers1()
        {
            var users = await context.Users.ToListAsync();
          //  var usersToRetune = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUserNameAsync(username);
            var userToReturn = _mapper.Map<MemberDto>(user);
            return Ok(userToReturn);

        }
    }
}
