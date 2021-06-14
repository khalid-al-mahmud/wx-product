using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class Special
    {
        [JsonProperty("quantities")]
        public List<ItemQuantity> Quantities { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}