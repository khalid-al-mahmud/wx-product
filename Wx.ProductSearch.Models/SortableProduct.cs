namespace Wx.ProductSearch.Models
{
    public class SortableProduct : Product
    {
        private double? _saleCount = 0;
        public double SaleCount
        {
            get { return _saleCount ?? 0; }
            set { _saleCount = value; }
        }
    }
}