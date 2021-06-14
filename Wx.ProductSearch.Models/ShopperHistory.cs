using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class ShopperHistory
    {
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}