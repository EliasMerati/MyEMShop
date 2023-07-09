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
        bool FinallyOrder(string userName, int orderId);
        IList<Order> GetUserOrders(string userName);

    }
}
