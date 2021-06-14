using System.Collections.Generic;
using System.Threading.Tasks;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<List<ShopperHistory>> GetShopperHistory();
    }
}