using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class LowSortingAlgorithm : ISortingAlgorithm
    {
        private readonly List<Product> _products;

        private LowSortingAlgorithm(List<Product> products)
        {
            _products = products;
        }

        public static LowSortingAlgorithm Create(List<Product> products)
        {
            return new LowSortingAlgorithm(products);
        }
        public List<Product> Sort()
        {
            var sortedProducts = _products.OrderBy(p => p.Price).ToList();
            return sortedProducts;
        }

    }
}
