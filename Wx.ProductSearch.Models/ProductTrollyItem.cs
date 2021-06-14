using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class ProductTrollyItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}