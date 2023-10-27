using System;

namespace MyEMShop.Data.Dtos.VisitorDto
{
    public record VisitorsDto
    {
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public DateTime Time { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public bool IsSpider { get; set; }
    }
}
