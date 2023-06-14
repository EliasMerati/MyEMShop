using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Data.Dtos
{
    public record ProductDto
    {
        public Product Product { get; set; }
        IList<ProductImage> images { get; set; }
    }
}
