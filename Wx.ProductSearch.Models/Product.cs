using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.Text;

namespace Wx.ProductSearch.Models
{

    public class Product
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }
    }
}