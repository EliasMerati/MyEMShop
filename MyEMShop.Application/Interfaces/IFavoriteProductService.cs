namespace MyEMShop.Application.Interfaces
{
    public interface IFavoriteProductService
    {
        void AddToFavorites(int userId , int productId);
    }
}
