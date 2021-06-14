using Newtonsoft.Json;

namespace Wx.ProductSearch.Models
{
    public class TestUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}