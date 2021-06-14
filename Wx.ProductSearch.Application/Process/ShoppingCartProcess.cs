using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wx.ProductSearch.Application.Services;

using Wx.ProductSearch.Domain.Cart;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Application.Process
{
    public class ShoppingCartProcess : IShoppingCartProcess
    {
        private readonly IProductService _productService;
        private readonly ISortingService _sortingService;

        public ShoppingCartProcess(
            IProductService productService,
            ISortingService sortingService)
        {
            _productService = productService;
            _sortingService = sortingService;
        }

        public async Task<List<Product>> SortProducts(string sortOption)
        {
            var products = await _productService.GetProducts();
            var productHistory = await GetProductHistory();

            var sortingAlgorthm = sortOption.ParseSelectedSortingOption();
         
            var sortedProducts = _sortingService.Sort(sortingAlgorthm, products, productHistory);
            return sortedProducts;
        }

        private async Task<List<Product>> GetProductHistory()
        {
            var shopperHistory = await _productService.GetShopperHistory();
            var productHistory = shopperHistory?.SelectMany(p => p.Products.Select(x => x)).ToList()??
                                 new List<Product>();
            return productHistory;
        }
       

        public Task<decimal> CalculateShoppingCart(Trolly trolly)
        {
            var shoppingCart = ShoppoingCart.Create(trolly);
            var total = shoppingCart.Calculate();

            return Task.FromResult(total);
        }
    }
}
