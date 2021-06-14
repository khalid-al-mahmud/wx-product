using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Wx.ProductSearch.Domain.Config;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;

namespace Wx.ProductSearch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationConfiguration _config;


        public ProductService(IOptions<ApplicationConfiguration> config)
        {
            _config = config.Value;
        }

      
        public async Task<List<Product>> GetProducts()
        {

            try
            {
              
                var productUrl = Url.Combine(_config.ApiBaseUrl, "api", "resource", "products");
                var products = await productUrl.SetQueryParam("token", _config.ApiKey)
                    .GetJsonAsync<List<Product>>();

                return products;
            }
            catch (Exception ex)
            {
                //Log error to appinsight and take 
                return  new List<Product>();
            }
        }
        
       

        public async Task<List<ShopperHistory>> GetShopperHistory()
        {
            try
            {
                var productUrl = Url.Combine(_config.ApiBaseUrl, "api", "resource", "shopperHistory");
                var products = await productUrl.SetQueryParam("token", _config.ApiKey)
                    .GetJsonAsync<List<ShopperHistory>>();

                return products;
            }
            catch (Exception ex)
            {

                //Log error to appinsight and take 
                return new List<ShopperHistory>();
            }
        }

    }

}
