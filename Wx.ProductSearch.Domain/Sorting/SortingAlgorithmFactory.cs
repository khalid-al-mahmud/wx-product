using System;
using System.Collections.Generic;

using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Sorting
{
    public class SortingAlgorithmFactory : ISortingAlgorithmFactory
    {
      

        public SortingAlgorithmFactory() { }

        public ISortingAlgorithm Get(SortingAlgorithm sortingAlgorithm, List<Product> products, List<Product> productHistory )
        {

            switch (sortingAlgorithm)
            {
                case SortingAlgorithm.Low: return  LowSortingAlgorithm.Create(products);
                case SortingAlgorithm.High: return  HighSortingAlgorithm.Create(products);
                case SortingAlgorithm.Ascending: return  AscendingSortingAlgorithm.Create(products);
                case SortingAlgorithm.Descending: return  DescendingSortingAlgorithm.Create(products);
                case SortingAlgorithm.Recommended: return  RecommendedSortingAlgorithm.Create(products,productHistory);

                default: return LowSortingAlgorithm.Create(products);
            }
        }
    }
}