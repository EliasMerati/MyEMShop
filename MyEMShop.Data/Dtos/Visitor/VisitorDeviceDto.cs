namespace MyEMShop.Data.Dtos.Visitor
{
    public record VisitorDeviceDto
    {
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }
        public bool IsSpider { get; set; }
    }
}
