using AutoMapper;
using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(UserManager<User> userManager, RegisterCustomerDTO model, IMapper mapper);
        Task<Customer> GetCustomerByID(object Id);
        Task<int> Save();
        Task<bool> FundWallet(int id, FundCustomerDTO model);
        Customer FindByAccountNumber(double acct);
    }
}
