using ShopWest.Shared;

namespace ShopWest.Client.Services;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem item);
    Task<List<CartItem>> GetCartItems();
    Task DeleteItem(CartItem item);
    Task EmptyCart();
}