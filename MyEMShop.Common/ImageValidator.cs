using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MyEMShop.Common
{
    public static class ImageValidator
    {
        public static bool IsImage(this IFormFile img)
        {
            try
            {
                var image = System.Drawing.Image.FromStream(img.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
