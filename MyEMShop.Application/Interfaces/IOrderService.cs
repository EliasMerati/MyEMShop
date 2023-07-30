using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Dtos.OrderState;
using MyEMShop.Data.Entities.Order;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string userName, int productId);
        void UpdatePriceOrder(int orderId);
        Order GetOrderForUserPannel(string userName, int orderId);
        Order GetOrderById(int orderId);
        void UpdateOrder(Order order);
        bool FinallyOrder(string userName, int orderId);
        IList<Order> GetUserOrders(string userName);
        Order OrderNotPayment();
        List<OrdersDto> GetOrdersForAdmin(OrderState orderState);
        void DeleteFromOrder(int orderId ,int productid);
        bool IsOrderExist(int orderId);
        void DeleteOrder(int orderId);
        void Refresh(int quantity, int orderId, int productId);
        void ChangeStateToIsSend(int orderId);
        void ChangeStateToIsReady(int orderId);
        void ChangeStateToIsCancelled(int orderId);
        Order ShowOrderForAdmin(int orderId ,int userId);
    }
}
