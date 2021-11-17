using BankAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.SeedConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData
            (
            new User
            {
                Id = "1",
                Firstname = "Try",
                Lastname = "Kach",
                Email = "trykach@api.com",
                PhoneNumber = "08080808080",
                UserName = "kes",
                PasswordHash = hasher.HashPassword(null, "@Secret1234")
            },
            new User
            {
                Id = "2",
                Firstname = "User",
                Lastname = "Kach",
                Email = "trykachuser@api.com",
                PhoneNumber = "07080808080",
                UserName = "ken",
                PasswordHash = hasher.HashPassword(null, "@Secret1234")
            },
            new User
            {
                Id = "3",
                Firstname = "AnotherUser",
                Lastname = "Kach",
                Email = "trykachuser2@api.com",
                PhoneNumber = "06080808080",
                UserName = "kach",
                PasswordHash = hasher.HashPassword(null, "@Secret1234")
            },
            new User
            {
                Id = "4",
                Firstname = "merchant",
                Lastname = "Kach",
                Email = "trykachmerchant@api.com",
                PhoneNumber = "09080808080",
                UserName = "kumia",
                PasswordHash = hasher.HashPassword(null, "@Secret1234")
            });

        }
    }

}
