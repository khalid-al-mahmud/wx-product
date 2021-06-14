using System.Collections.Generic;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Interfaces
{
    public interface ISortingAlgorithmFactory
    {
        ISortingAlgorithm Get(SortingAlgorithm sortingAlgorithm, List<Product> products, List<Product> productHistory);
    }
}