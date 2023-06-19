using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Data.Dtos.ProductDto
{
    public record GetProductForAdminDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductPrice { get; set; }
        public string Productmark { get; set; }
    }
}
