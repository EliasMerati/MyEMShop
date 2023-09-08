using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Visitors
{
    public class VisitorBrowser
    {
        [Key]
        public int VisitorBrowserId { get; set; }
        public int VisitorId { get; set; }
        public string Family { get; set; }
        public string Version { get; set; }

        public ICollection<Visitor> Visitor { get; set; }
    }
}
