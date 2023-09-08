using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.Visitor;
using MyEMShop.Data.Entities.Visitors;

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
                    CurrentLink= visitor.CurrentLink,
                    Ip= visitor.Ip,
                    Method= visitor.Method,
                    VisitorDevice = new VisitorDevice { Brand = visitor.VisitorDevice.Brand,Family = visitor.VisitorDevice.Family , IsSpider = visitor.VisitorDevice.IsSpider,Model = visitor.VisitorDevice.Model },
                    OperationSystem = new VisitorOs { Family = visitor.OperationSystem.Family, Version = visitor.OperationSystem.Version },
                    PhisicalPath= visitor.PhisicalPath,
                    Protocol= visitor.Protocol,
                    ReferrerLink = visitor.ReferrerLink
                };
                _db.Add(visitors);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }

        public void UpdateVisitor(Visitor visitor)
        {
            try
            {
                _db.Update(visitor);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
        }
    }
}
