using BankAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.SeedConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData
            (
            new Role
            {
                Id = "1",
                Name = "customer",
                CreatedAt = DateTime.Now,
            },
            new Role
            {
                Id = "2",
                Name = "Admin",
                CreatedAt = DateTime.Now
            });

        }
    }
}
