namespace MyEMShop.Data.Dtos.ProductDto
{
    public record GetProductForAdminDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductPrice { get; set; }
        public string Productmark { get; set; }
        public string MainImageProduct { get; set; }
    }
}
