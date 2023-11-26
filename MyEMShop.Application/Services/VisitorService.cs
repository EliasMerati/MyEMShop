using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.VisitorDto;
using MyEMShop.Data.Entities.Visitors;
using System;
using System.Collections.Generic;
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
                    VisitorId = visitor.VisitorId,
                    Browser = new VisitorBrowser { VisitorId = visitor.VisitorId, Family = visitor.Browser.Family, Version = visitor.Browser.Version },
                    CurrentLink = visitor.CurrentLink,
                    Ip = visitor.Ip,
                    VisitID = visitor.VisitID,
                    Time = DateTime.Now,
                    Method = visitor.Method,
                    VisitorDevice = new VisitorDevice {VisitorId = visitor.VisitorId, Brand = visitor.VisitorDevice.Brand, Family = visitor.VisitorDevice.Family, IsSpider = visitor.VisitorDevice.IsSpider, Model = visitor.VisitorDevice.Model },
                    OperationSystem = new VisitorOs { VisitorId = visitor.VisitorId, Family = visitor.OperationSystem.Family, Version = visitor.OperationSystem.Version },
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

        public List<VisitorsDto> GetLast10Visitors()
        {
            return _db.Visitors
                .OrderByDescending(v => v.Time)
                .Select(v => new VisitorsDto
                {
                    Browser = v.Browser.Family,
                    Time= v.Time,
                    CurrentLink= v.CurrentLink,
                    Ip = v.Ip,
                    IsSpider = v.VisitorDevice.IsSpider,
                    OperationSystem= v.OperationSystem.Family,
                    ReferrerLink = v.ReferrerLink
                }).Take(10).ToList();
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

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).GroupBy(v => v.VisitID).LongCount();
        }
        public long MonthVisitors()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddMonths(1);

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).GroupBy(v => v.VisitID).LongCount();
        }

        public long TodayVisits()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).LongCount();
        }
        public long MonthVisits()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddMonths(1);

            return _db.Visitors.Where(v => v.Time >= start && v.Time < end).LongCount();
        }

        public long TotalUsers()
        {
            return _db.Users.LongCount();
        }

        public long TotalVisitors()
        {
            return _db.Visitors.GroupBy(v => v.VisitID).LongCount();
        }

        public long TotalVisits()
        {
            return _db.Visitors.LongCount();
        }
    }
}
