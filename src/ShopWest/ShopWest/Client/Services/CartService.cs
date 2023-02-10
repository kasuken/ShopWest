using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using ShopWest.Shared;

namespace ShopWest.Client.Services;

public class CartService : ICartService
{
    private readonly ILocalStorageService localStorage;
    private readonly IToastService toastService;

    public event Action OnChange;

    public CartService(ILocalStorageService localStorage, IToastService toastService)
    {
        this.localStorage = localStorage;
        this.toastService = toastService;
    }

    public async Task AddToCart(CartItem item)
    {
        var cart = await this.localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        var sameItem = cart.Find(x => x.ProductId == item.ProductId);
        if (sameItem == null)
        {
            cart.Add(item);
        }
        else
        {
            sameItem.Quantity += item.Quantity;
        }

        await this.localStorage.SetItemAsync("cart", cart);
        
        // _toastService.ShowSuccess(item.ProductTitle, "Added to cart:");

        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var cart = await this.localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return new List<CartItem>();
        }

        return cart;
    }

    public async Task DeleteItem(CartItem item)
    {
        var cart = await this.localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }

        var cartItem = cart.Find(x => x.ProductId == item.ProductId);
        cart.Remove(cartItem);

        await this.localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task EmptyCart()
    {
        await this.localStorage.RemoveItemAsync("cart");
        OnChange.Invoke();
    }
}