using AutoMapper;
using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Controllers
{
    [Route("api/Customer/[action]")]
    [ApiController]
    //[Authorize(Policy = "CustomerRolePolicy")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;

        public CustomerController(UserManager<User> userManager, IMapper mapper, ICustomerService customerService, ITransactionService transactionService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _customerService = customerService;
            _transactionService = transactionService;
        }
        
        [HttpPost()]
        public async Task<IActionResult> Transfer([FromBody] TransferDTO model)
        {
            if (model == null)
                return BadRequest("model object is null");

            var result = await _transactionService.Transfer(model);
            if (!result)
                return Forbid();
            return Ok("Success");
        }
    }
}
