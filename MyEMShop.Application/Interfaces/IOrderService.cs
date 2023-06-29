using MyEMShop.Data.Entities.Order;

namespace MyEMShop.Application.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string userName, int productId);
        void UpdatePriceOrder(int orderId);
        Order GetOrderForUserPannel(string userName, int orderId);
        bool FinallyOrder(string userName, int orderId);
    }
}
