using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class HighSortingAlgorithm : ISortingAlgorithm
    {
        private readonly List<Product> _products;

        public HighSortingAlgorithm(List<Product> products)
        {
            _products = products;
        }
        public static HighSortingAlgorithm Create(List<Product> products)
        {
            return new HighSortingAlgorithm(products);
        }
        public List<Product> Sort()
        {
            var sortedProducts = _products.OrderByDescending(p => p.Price).ToList();
            return sortedProducts;
        }

    }
}