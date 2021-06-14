namespace Wx.ProductSearch.Models
{
    public class ProductLineItem
    {
        private  ProductLineItem( string name, decimal price, int saleQuantity)
        {
            this.Name = name;
            this.Price = price;
            this.SaleQuantity = saleQuantity;
        }

        public static ProductLineItem Create(string name, decimal price, int saleQuantity)
        {
            return new ProductLineItem(name,price,saleQuantity);
        }

        public void AddSpecialQuantity(int quantity)
        {
            SpecialQuantity = SpecialQuantity + quantity;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int SaleQuantity { get;private set; }
        public int SpecialQuantity { get; private set; }
        public int Quantity => SaleQuantity - SpecialQuantity;
        public decimal Total => Quantity * Price;
    }
}