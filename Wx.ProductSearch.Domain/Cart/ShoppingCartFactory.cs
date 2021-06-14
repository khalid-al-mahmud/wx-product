using System;
using System.Collections.Generic;
using System.Text;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Cart
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {

        public ShoppoingCart Get(Trolly trolly)
        {
            return ShoppoingCart.Create(trolly);
        }
    }
}
