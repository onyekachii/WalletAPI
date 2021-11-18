using BankAPI.Models.DataBaseContext;
using BankAPI.Models.Entities;
using BankAPI.Models.Entities.Enum;
using BankAPI.Models.SeedConfiguration;
using BankAPI.Models.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.SeedConfiguration
{
    public class SeedUsers
    {
        static readonly User Admin = new User
        {         
            Id = "1",
            Firstname = "Try",
            Lastname = "Kach",
            Email = "trykach@api.com",
            PhoneNumber = "08080808080",
            UserName = "kes",            
        };
        static readonly User User1 = new User
        {            
            Id= "2",
            Firstname = "User",
            Lastname = "Kach",
            Email = "trykachuser@api.com",
            PhoneNumber = "07080808080",
            UserName = "ken"            
        };
        static readonly User User2 = new User
        {            
            Id ="3",
            Firstname = "AnotherUser",
            Lastname = "Kach",
            Email = "trykachuser2@api.com",
            PhoneNumber = "06080808080",
            UserName = "kach"            
        };
        static readonly User merchant = new User
        {            
            Id = "4",
            Firstname = "merchant",
            Lastname = "Kach",
            Email = "trykachmerchant@api.com",
            PhoneNumber = "09080808080",
            UserName = "kumia"            
        };      

        static UserManager<User> _userManager;
        static KachContext _context;

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            _context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<KachContext>();
            if (_context.Database.IsRelational())
                if ((await _context.Database.GetPendingMigrationsAsync()).Any())
                    await _context.Database.MigrateAsync();

            _userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();

            await CreateUser(Admin, "Admin", "@secret1234");
            await CreateUser(User1, "User", "@secret1234");
            await CreateUser(User2, "User", "@secret1234");
            await CreateUser(merchant, "Merchant", "@secret1234");
            await UpdateCustomerTable();
        }

        static async Task CreateUser(User defaultUser, string role, string password)
        {
            var user = await _userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
                user = await _userManager.FindByNameAsync(defaultUser.UserName);
            if (user != null) return;

            var createUser = await _userManager.CreateAsync(defaultUser, password);
            if (createUser.Succeeded) await _userManager.AddToRoleAsync(defaultUser, role);
        }

        private static async Task UpdateCustomerTable()
        {
            var customer = _context.Customers.ToList();
            if (customer.Count <= 3)
            {
                List<User> Allusers = new List<User>();
                Allusers.Add(User1);
                Allusers.Add(User2);
                Allusers.Add(merchant);

                for (var i = 0; i < customer.Count; i++)
                {
                    customer[i].UserId = Allusers[i].Id;
                    _context.Update(customer[i]);
                }
                await _context.SaveChangesAsync();
            }

        }
    }
}
