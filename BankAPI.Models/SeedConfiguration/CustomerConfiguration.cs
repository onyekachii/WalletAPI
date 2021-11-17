using BankAPI.Models.Entities;
using BankAPI.Models.Entities.Enum;
using BankAPI.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.SeedConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData
        (
        new Customer
        {
            Id = 1,
            AccountNumber= AccountGenerator.GenerateAccountNumber(),
            Balance = 1000,
            AccountType = AccountType.Student,
            UserId = "2",
            CreatedAt = DateTime.Now
        },
        new Customer
        {
            Id = 2,
            AccountNumber = AccountGenerator.GenerateAccountNumber(),
            Balance = 5000,
            AccountType = AccountType.Savings,
            UserId = "3",
            CreatedAt = DateTime.Now
        },
        new Customer
        {
            Id = 3,
            AccountNumber = AccountGenerator.GenerateAccountNumber(),
            Balance = 1000,
            AccountType = AccountType.Merchant,
            UserId = "4",
            CreatedAt = DateTime.Now
        }
        );

    }
}
    
}
