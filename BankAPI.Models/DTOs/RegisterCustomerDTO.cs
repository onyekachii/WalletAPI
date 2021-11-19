using BankAPI.Models.Entities;
using BankAPI.Models.Entities.Enum;
using BankAPI.Models.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.DTOs
{
    public class RegisterCustomerDTO
    {                
        public double Balance { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Ensure you input a name")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Ensure you input a name")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Ensure you input a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ensure you input an email")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
