using System;

namespace MyEMShop.Common
{
    public class GenerateCode
    {
        public static string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
