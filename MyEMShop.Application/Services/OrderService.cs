using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using System;

namespace MyEMShop.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public OrderService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion


        public int AddOrder(string userName, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
