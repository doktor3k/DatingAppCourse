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
        private readonly DataContext _context;

        public UsersController(IUserRepository userRepository, IMapper mapper, DataContext context)
        {
        
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._context = context;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);
        }
        

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
           

        }
    }
}
