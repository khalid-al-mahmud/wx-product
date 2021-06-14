using System.Collections.Generic;
using System.Linq;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Domain.Cart
{
    public class ShoppoingCart
    {

        public Trolly _trolly;
        private List<ProductLineItem> LineItems = new List<ProductLineItem>();
        private decimal TotalSpecialPrice = 0;


        public ShoppoingCart(Trolly trolly)
        {
            _trolly = trolly;
            BuildLineItems();
        }

        public static ShoppoingCart Create(Trolly trolly)
        {
            return  new ShoppoingCart(trolly);
        }

        public decimal Calculate()
        {
            foreach (var special in _trolly.Specials.OrderByDescending(s=>s.Total))
            {
                var specialProducts = special.Quantities.Select(p => p).ToList();

                while (IsSpecialApplicable(LineItems, special))
                {
                    ApplySpecial(LineItems, special);
                }
            }
            return TotalLineItemPrice + TotalSpecialPrice;
        }


        public bool IsSpecialApplicable(List<ProductLineItem> LineItems, Special special)
        {
            var specialQuantities = special.Quantities.Select(p => p).ToList();
            foreach (var specialProduct in specialQuantities)
            {
                var productLineItem = LineItems.FirstOrDefault(l => l.Name.Equals(specialProduct.Name));
                if (productLineItem == null)
                    return false;
                if (productLineItem.Quantity < specialProduct.Quantity)
                    return false;
            }

            return true;
        }

        public bool ApplySpecial(List<ProductLineItem> LineItems, Special special)
        {
            var specialQuantities = special.Quantities.Select(p => p).ToList();
            foreach (var specialQuantity in specialQuantities)
            {
                var productLineItem = LineItems.FirstOrDefault(l => l.Name.Equals(specialQuantity.Name));
                if (productLineItem == null)
                    return false;
                if (productLineItem.Quantity < specialQuantity.Quantity)
                    return false;

                productLineItem.AddSpecialQuantity(specialQuantity.Quantity);
            }
            TotalSpecialPrice = TotalSpecialPrice + special.Total;
            return true;
        }


        private decimal TotalLineItemPrice => LineItems.Sum(l => l.Total);
        
        private void BuildLineItems()
        {
            foreach (var trollyProduct in _trolly.Products)
            {
                var saleQuantity = GetSaleQuantity(trollyProduct.Name);
                var lineItem = ProductLineItem.Create(trollyProduct.Name,  trollyProduct.Price,saleQuantity);
                LineItems.Add(lineItem);
            }
        }
        private int GetSaleQuantity(string productNamae) => 
            _trolly.Quantities.FirstOrDefault(q => q.Name.Equals(productNamae))?.Quantity ?? default(int);
    }
}
