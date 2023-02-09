using ShopWest.Shared;
using Stripe;
using Product = ShopWest.Shared.Product;

namespace ShopWest.Server.Services
{
    public class ShopWestService : IShopWestService
    {
        public async Task<List<Product>> GetProducts()
        {
            var products = new List<Product>();

            StripeConfiguration.ApiKey = "sk_test_51BFN5cBHFTxI6VL5BnL8nDoWQ0yaZwHoxPh2pU42Kvlzl5eTrkulc9TWXLFXYrXvkGTukLxI9XFIb0SS6FZZwfpR00BRVTok1Z";

            var service = new ProductService();
            var stripeProducts = await service.ListAsync();

            return products;
        }
    }
}
