using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Cart
{
    public interface IShoppingCartFactory
    {
        ShoppoingCart Get(Trolly trolly);
    }
}