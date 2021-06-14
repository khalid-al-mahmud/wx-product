using System.Collections.Generic;

using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Interfaces
{
    public interface ISortingService
    {
        List<Product> Sort(SortingAlgorithm sortingAlgorithm, List<Product> products, List<Product> productHistory
        );
    }
}