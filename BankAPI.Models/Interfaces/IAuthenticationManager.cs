using BankAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(LoginDTO userForAuth);
        Task<string> CreateToken();
    }
}
