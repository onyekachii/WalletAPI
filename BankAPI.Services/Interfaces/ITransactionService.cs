using BankAPI.Models.DTOs;
using BankAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = BankAPI.Models.Entities.Transaction;

namespace BankAPI.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransaction(Transaction transaction);
        Task<bool> Transfer(TransferDTO model);
    }
}
