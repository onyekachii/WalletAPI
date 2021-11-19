using AutoMapper;
using BankAPI.ActionFilters;
using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/Admin/[action]")]
    [ApiController]
    //[Authorize(Policy = "AdminRolePolicy")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ICustomerService _customerService;

        public AdminController(UserManager<User> userManager, IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDTO model)
        {
            var result = await _customerService.CreateCustomer(_userManager, model, _mapper);
            if (!result)
                return BadRequest($"Invalid Registration. User may already exist");
            return Ok("Customer Registration was Successfully");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> FundCustomerWalletById(int id, [FromBody] FundCustomerDTO model)
        {            
            if (model == null)            
                return BadRequest("model object is null");

            var result = await _customerService.FundWallet(id, model);
            if (!result)
                return NotFound();
            return NoContent();            
        }

        //[HttpPost]
        //public async Task<IActionResult> DeactivateAccount();
    }
}
