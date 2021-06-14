using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class Trolly
    {
        [JsonProperty("products")]
        public List<ProductTrollyItem> Products { get; set; }

        [JsonProperty("specials")]
        public List<Special> Specials { get; set; }

        [JsonProperty("quantities")]
        public List<ItemQuantity> Quantities { get; set; }
    }
}