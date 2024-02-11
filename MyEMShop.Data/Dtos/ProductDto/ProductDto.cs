using System;

namespace MyEMShop.Data.Dtos.ProductDto
{
    public record GetProductForAdminDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string MainImageProduct { get; set; }
        public string Productmark { get; set; }
    }

    public record ShowProductForIndex
    {
        public int ProductId { get; set; }
        public int PL_Id { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string MainImageProduct { get; set; }
        public string ProductShortDescription { get; set; }
        public int Save { get; set; }
        public DateTime InsertDate { get; set; }
   
    }

    public record ShowMyFavoriteProductDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string MainImageProduct { get; set; }
        public int Save { get; set; }
        public int PL_Id { get; set; }
    }
}
