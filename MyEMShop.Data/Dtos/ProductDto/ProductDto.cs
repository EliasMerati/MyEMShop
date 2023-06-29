using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyEMShop.Data.Dtos.ProductDto
{
    public record GetProductForAdminDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string Productmark { get; set; }
        public string MainImageProduct { get; set; }
    }

    public record ShowProductForIndex
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string MainImageProduct { get; set; }
        public int Save { get; set; }
    }
}
