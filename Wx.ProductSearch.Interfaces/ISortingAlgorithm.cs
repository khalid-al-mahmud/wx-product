using System.Collections.Generic;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Interfaces
{
    public interface ISortingAlgorithm
    {
        List<Product> Sort();
    }
}