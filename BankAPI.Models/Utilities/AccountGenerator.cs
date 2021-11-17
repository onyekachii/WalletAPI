using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankAPI.Models.Utilities
{
    public static class AccountGenerator
    {
        public static double GenerateAccountNumber()
        {
            var milisecndns = string.Format("{0:000}", DateTime.Now.Millisecond);
            var year = DateTime.Now.ToString("yy");
            var month = string.Format("{0:00}", DateTime.Now.Month);
            var day = (RandomNumberGenerator.GetInt32(10, 99)).ToString();

            var str = year + month + milisecndns + day;
            return Convert.ToDouble(str);
        }
    }
}
