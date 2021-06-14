using System.Collections.Generic;

using Wx.ProductSearch.Domain.Sorting;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Application.Services
{
    public class SortingService : ISortingService
    {
        private readonly ISortingAlgorithmFactory _sortingAlgorithmFactory;


        public SortingService(ISortingAlgorithmFactory sortingAlgorithmFactory)
        {
            _sortingAlgorithmFactory = sortingAlgorithmFactory;
        }

        public List<Product> Sort(
            SortingAlgorithm sortingAlgorithm, 
            List<Product> products, 
            List<Product> productHistory
        )
        {
           
            var selectedSortingAlgorithm = _sortingAlgorithmFactory.Get(sortingAlgorithm,products,productHistory);
            var sortedProduct = selectedSortingAlgorithm.Sort();
            return sortedProduct;
        }
    }
}