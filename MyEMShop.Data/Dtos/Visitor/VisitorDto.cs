namespace MyEMShop.Data.Dtos.Visitor
{
    public record VisitorDto
    {
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhisicalPath { get; set; }
        public VisitorVersionDto Browser { get; set; }
        public VisitorVersionDto OperationSystem { get; set; }
        public VisitorDeviceDto VisitorDevice { get; set; }
    }
}
