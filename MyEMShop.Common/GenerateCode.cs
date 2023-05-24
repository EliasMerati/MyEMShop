using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Common
{
    public class GenerateCode
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
