using System.Collections.Generic;
using System.Threading.Tasks;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Interfaces
{
    public interface IShoppingCartProcess
    {
        Task<List<Product>> SortProducts(string sortOption);
        Task<decimal> CalculateShoppingCart(Trolly trolly);
    }
}