using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class AscendingSortingAlgorithm : ISortingAlgorithm
    {
        private readonly List<Product> _products;

        public AscendingSortingAlgorithm(List<Product> products)
        {
            _products = products;
        }

        public static AscendingSortingAlgorithm Create(List<Product> products)
        {
            return  new AscendingSortingAlgorithm(products);
        }
        public List<Product> Sort()
        {
            var sortedProducts = _products.OrderBy(p => p.Name).ToList();
            return sortedProducts;
        }

    }
}