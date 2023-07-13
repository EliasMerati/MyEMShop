using System;

namespace MyEMShop.Common
{
    public static class CatchHelper
    {
        public static readonly TimeSpan DefaultCatchDuration = TimeSpan.FromSeconds(60);

        public static string GenerateShowProductCacheKey()
        {
            return "ShowProduct";
        }
    }
}
