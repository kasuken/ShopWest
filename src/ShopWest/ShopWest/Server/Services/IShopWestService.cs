using ShopWest.Shared;

namespace ShopWest.Server.Services
{
    public interface IShopWestService
    {
        Task<List<Product>> GetProducts();
    }
}
