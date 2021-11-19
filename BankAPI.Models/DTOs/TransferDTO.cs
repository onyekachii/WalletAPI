using BankAPI.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.DTOs
{
    public class TransferDTO
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public double AccountNumber { get; set; }

        [Required]
        public int SenderId { get; set; }

    }
}
