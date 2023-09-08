using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Visitors
{
    public class VisitorDevice
    {
        [Key]
        public int VisitorDeviceId { get; set; }
        public int VisitorId { get; set; }
        public string Brand { get; set; }
        public string Family { get; set; }
        public string Model { get; set; }
        public bool IsSpider { get; set; }

        public ICollection<Visitor> Visitor { get; set; }
    }
}
