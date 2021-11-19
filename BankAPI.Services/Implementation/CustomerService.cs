using AutoMapper;
using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using BankAPI.Models.Entities.Enum;
using BankAPI.Models.Utilities;
using BankAPI.Repository.Interfaces;
using BankAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IServiceFactory _serviceFactory;

        public CustomerService(IUnitofWork unitofWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitofWork;
            _customerRepo = unitofWork.GetRepository<Customer>();
            _serviceFactory = serviceFactory;
        }

        public async Task<bool> CreateCustomer(UserManager<User> userManager, RegisterCustomerDTO model, IMapper mapper)
        {
            var existingUser = await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
                return false;

            User newUser = mapper.Map<User>(model);
            var result = await userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                return false;
            await userManager.AddToRoleAsync(newUser, "User");

            Customer newCustomer = mapper.Map<Customer>(model);
            newCustomer.AccountNumber = AccountGenerator.GenerateAccountNumber();
            newCustomer.UserId = newUser.Id;
            await _customerRepo.AddAsync(newCustomer);            
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomerByID(object Id)
        {
            var customer = await _customerRepo.GetAsync(Id);
            if (customer.IsDeleted)            
                return null;
            
            return customer;
        }

        public async Task<int> Save() => await _unitOfWork.SaveChangesAsync();

        public async Task<bool> FundWallet(int id, FundCustomerDTO model)
        {
            Customer customer = await GetCustomerByID(id);

            if (customer is null || customer.UserId is null)
                return false;

            customer.Balance += model.Amount;
            var transaction = new Transaction
            {
                Amount = model.Amount,
                RecipientId = customer.CustomerId,
                SenderId = customer.CustomerId,
                TransactionTime = DateTime.Now,
                TransactionType = TransactionType.Credit
            };
            var transactionService = _serviceFactory.GetServices<ITransactionService>();
            await transactionService.AddTransaction(transaction);
            await Save();
            return true;
        }

        
        public Customer FindByAccountNumber(double acct)
        {
            return _customerRepo.Find(x => x.AccountNumber == acct).FirstOrDefault();
        }
    }
}