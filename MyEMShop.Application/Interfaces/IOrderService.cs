using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Entities.Order;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string userName, int productId);
        void UpdatePriceOrder(int orderId);
        Order GetOrderForUserPannel(string userName, int orderId);
        Order GetOrderById( int orderId);
        void UpdateOrder(Order order);
        Discount GetDiscount(string code);
        bool FinallyOrder(string userName, int orderId);
        IList<Order> GetUserOrders(string userName);

        #region Discount
        DiscountUseType UseDiscount(int orderId, string code);
        #endregion
    }
}
