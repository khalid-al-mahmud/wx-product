using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class ItemQuantity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}