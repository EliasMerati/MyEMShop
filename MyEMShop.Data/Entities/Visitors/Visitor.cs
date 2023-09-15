using System;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Visitors
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhisicalPath { get; set; }
        public DateTime Time { get; set; }
        public string VisitID { get; set; }


        public VisitorBrowser Browser { get; set; }

        public VisitorOs OperationSystem { get; set; }

        public VisitorDevice VisitorDevice { get; set; }
    }
}
