using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        // public IUserRepository _userRepository { get; }
        private readonly UserManager<Users> _userRepository;

        private readonly TokenService _tokenService;

        public AccountController(UserManager<Users> userRepository, TokenService tokenService) 
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userRepository.FindByNameAsync(loginDto.UserName);

            if (user == null || !await _userRepository.CheckPasswordAsync(user, loginDto.Password) )
                return Unauthorized("Invalid username");
           
            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };

       
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users>> Register(RegisterDto registerDto)
        {
           var user = new Users
           {
               UserName = registerDto.UserName,
                Email = registerDto.Email
           };

           var result = await _userRepository.CreateAsync(user, registerDto.Password);

           if(!result.Succeeded) 
           {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
           }
              await _userRepository.AddToRoleAsync(user, "Member");
              return StatusCode(201);
        }

        [Authorize]
        [HttpGet("currentUser")]

        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userRepository.FindByNameAsync(User.Identity.Name);
            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }         
    }
}