using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class RecommendedSortingAlgorithm : ISortingAlgorithm
    {
        private readonly List<Product> _products;
        private readonly List<Product> _productHistory;

        public RecommendedSortingAlgorithm(List<Product> products, List<Product> productHistory)
        {
            _products = products;
            _productHistory = productHistory;
        }

        public static RecommendedSortingAlgorithm Create(List<Product> products, List<Product> productHistory)
        {
            return new RecommendedSortingAlgorithm(products, productHistory);
        }
        public List<Product> Sort()
        {

            var productPopularity = _productHistory
                    .GroupBy(n => n.Name)
                    .Select(n => new ProductSaleCount
                        {
                            Name = n.Key,
                            SaleCount = n.Sum(x => x.Quantity)
                        }
                    )
                ;


            var sortedProducts = (from left in _products
                join right in productPopularity on left.Name equals right.Name into joinedList
                from sub in joinedList.DefaultIfEmpty()
                select new SortableProduct()
                {
                    Name = left.Name,
                    Price = left.Price,
                    Quantity = left.Quantity,
                    SaleCount = sub?.SaleCount ?? 0
                }).ToList().OrderByDescending(a => a.SaleCount).ToList();

            return sortedProducts.Select(s => (Product)s).ToList();
        }

    }
}