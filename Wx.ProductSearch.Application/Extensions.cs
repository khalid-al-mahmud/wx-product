using System;
using System.Collections.Generic;
using System.Text;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Application
{
    public static class Extensions
    {

        public static SortingAlgorithm ParseSelectedSortingOption(this string sortOption)
        {
            return Enum.TryParse(sortOption, true, out SortingAlgorithm sortingAlgorthm) ? 
                sortingAlgorthm : 
                SortingAlgorithm.Default;
        }
    }

    
}
