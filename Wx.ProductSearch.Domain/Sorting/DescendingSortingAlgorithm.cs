using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class DescendingSortingAlgorithm : ISortingAlgorithm
    {
        private readonly List<Product> _products;

        public DescendingSortingAlgorithm(List<Product> products)
        {
            _products = products;
        }

        public static DescendingSortingAlgorithm Create(List<Product> products)
        {
            return new DescendingSortingAlgorithm(products);
        }
        public List<Product> Sort()
        {
            var sortedProducts = _products.OrderByDescending(p => p.Name).ToList();
            return sortedProducts;
        }

    }
}