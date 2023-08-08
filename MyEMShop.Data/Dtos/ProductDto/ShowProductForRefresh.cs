namespace MyEMShop.Data.Dtos.ProductDto
{
    public record ShowProductForRefresh
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
    }
}
