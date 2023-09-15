using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Visitors;
using System;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class VisitorService : IVisitorService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public VisitorService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddVisitorInfo(Visitor visitor)
        {
            try
            {
                var visitors = new Visitor()
                {
                    Browser = new VisitorBrowser { Family = visitor.Browser.Family, Version = visitor.Browser.Version },
                    CurrentLink = visitor.CurrentLink,
                    Ip = visitor.Ip,
                    VisitID = visitor.VisitID,
                    Time = DateTime.Now,
                    Method = visitor.Method,
                    VisitorDevice = new VisitorDevice { Brand = visitor.VisitorDevice.Brand, Family = visitor.VisitorDevice.Family, IsSpider = visitor.VisitorDevice.IsSpider, Model = visitor.VisitorDevice.Model },
                    OperationSystem = new VisitorOs { Family = visitor.OperationSystem.Family, Version = visitor.OperationSystem.Version },
                    PhisicalPath = visitor.PhisicalPath,
                    Protocol = visitor.Protocol,
                    ReferrerLink = visitor.ReferrerLink
                };
                _db.Add(visitors);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }

        public int NewOrder()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);
            return _db.Orders.Where(o => o.OrderDate >= start && o.OrderDate < end && o.IsFinally).Count();
        }

        public long TodayVisitors()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).GroupBy(v => v.VisitorId).LongCount();
        }

        public long TodayVisits()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).LongCount();
        }

        public long TotalUsers()
        {
            return _db.Users.LongCount();
        }

        public long TotalVisitors()
        {
            return _db.Visitors.GroupBy(v => v.VisitorId).LongCount();
        }

        public long TotalVisits()
        {
            return _db.Visitors.LongCount();
        }
    }
}
