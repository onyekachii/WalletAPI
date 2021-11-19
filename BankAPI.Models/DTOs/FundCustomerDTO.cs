using BankAPI.Models.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.DTOs
{
    public class FundCustomerDTO
    {
        [Required]
        public double Amount { get; set; }
    }
}
