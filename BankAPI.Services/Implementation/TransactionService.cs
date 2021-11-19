using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using BankAPI.Models.Entities.Enum;
using BankAPI.Repository.Interfaces;
using BankAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = BankAPI.Models.Entities.Transaction;
using uUserIdentity = System.Security.Principal;

namespace BankAPI.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IRepository<Transaction> _transactionRepo;
        private readonly IServiceFactory _serviceFactory;

        public TransactionService(IUnitofWork unitofWork, IServiceFactory serviceFactory)
        {
            _unitOfWork = unitofWork;
            _transactionRepo = unitofWork.GetRepository<Transaction>();
            _serviceFactory = serviceFactory;
        }
                
        public async Task AddTransaction(Transaction transaction)
        {
            await _transactionRepo.AddAsync(transaction);
        }

        public async Task<bool> Transfer(TransferDTO model)
        {
            var customerService = _serviceFactory.GetServices<ICustomerService>();
            var sender = await customerService.GetCustomerByID(model.SenderId);
            var recipient = customerService.FindByAccountNumber(model.AccountNumber);
            if (!(sender.Balance >= model.Amount))
                return false;
            else            
            {
                sender.Balance -= model.Amount;
                recipient.Balance += model.Amount;
            }
            var transactionTime = DateTime.Now;
            var transaction1 = new Transaction
            {
                Amount = model.Amount,
                RecipientId = recipient.CustomerId,
                SenderId = sender.CustomerId,
                TransactionTime = transactionTime,
                TransactionType = TransactionType.Credit
            };
            var transaction2 = new Transaction
            {
                Amount = model.Amount,
                RecipientId = recipient.CustomerId,
                SenderId = sender.CustomerId,
                TransactionTime = transactionTime,
                TransactionType = TransactionType.Debit
            };
            await AddTransaction(transaction1);
            await AddTransaction(transaction2);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
