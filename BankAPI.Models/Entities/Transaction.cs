using BankAPI.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public int RecipientId { get; set; }
        public int SenderId { get; set; }
    }
}
