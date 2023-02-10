using ShopWest.Shared;
using Stripe;
// using Product = ShopWest.Shared.Product;

namespace ShopWest.Server.Services
{
    public class ShopWestService : IShopWestService
    {
        private IConfiguration configuration;
        
        public ShopWestService(IConfiguration configuration)
        {
            this.configuration = configuration;
            StripeConfiguration.ApiKey = this.configuration.GetValue<string>("StripeSettings:SecretKey");
        }
        
        public async Task<List<ShopWest.Shared.Product>> GetProducts()
        {
            try
            {
                var products = new List<ShopWest.Shared.Product>();
            
                var service = new ProductService();
                var stripeProducts = await service.ListAsync();

                foreach (var item in stripeProducts)
                {
                    var priceService = new PriceService();
                    var price = await priceService.GetAsync(item.DefaultPriceId);
                    
                    products.Add(new ShopWest.Shared.Product() { Id = item.Id, Name  = item.Name, Price = (price.UnitAmount / 100).ToString(), PriceId = item.DefaultPriceId, ImageUrl =  item.Images[0], Type = price.Type} );
                }

                return products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
