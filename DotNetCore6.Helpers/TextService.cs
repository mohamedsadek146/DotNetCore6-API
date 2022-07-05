using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore6.Services.Helpers
{
    public class TextService
    {
        public static string CreateRandomCode(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-";
            string code= new string(Enumerable.Repeat(chars, length)
                 .Select(s => s[random.Next(s.Length)]).ToArray());

            return code;
        }
    }
}
