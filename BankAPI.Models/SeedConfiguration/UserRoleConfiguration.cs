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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData
            (
            new IdentityUserRole<string>
            {
                RoleId = "2",
                UserId = "1"
            },
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "2"
            },
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "3"
            },
            new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "4"
            });

        }
    }
}
