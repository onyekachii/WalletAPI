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
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
