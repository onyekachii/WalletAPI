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
            CustomerId = 1,
            AccountNumber= AccountGenerator.GenerateAccountNumber(),
            Balance = 1000,
            AccountType = AccountType.Student,
            CreatedAt = DateTime.Now
        },
        new Customer
        {
            CustomerId = 2,
            AccountNumber = AccountGenerator.GenerateAccountNumber(),
            Balance = 10000,
            AccountType = AccountType.Savings,
            CreatedAt = DateTime.Now
        },
        new Customer
        {
            CustomerId = 3,
            AccountNumber = AccountGenerator.GenerateAccountNumber(),
            Balance = 100000,
            AccountType = AccountType.Merchant,
            CreatedAt = DateTime.Now
        }
        );

    }
}
    
}
