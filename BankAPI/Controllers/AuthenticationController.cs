using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using BankAPI.Repository.Implementations;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginModel)
        {            
            if (!await _authManager.ValidateUser(loginModel))
                return Unauthorized();
            
            return Ok(new { Token = await _authManager.CreateToken() });
        }

    }
}
