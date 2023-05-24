using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Common
{
    public class FixedEmail
    {
        public static string Fix(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
