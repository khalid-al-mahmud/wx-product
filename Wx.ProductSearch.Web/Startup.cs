using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wx.ProductSearch.Application;
using Wx.ProductSearch.Application.Process;
using Wx.ProductSearch.Application.Services;
using Wx.ProductSearch.Domain.Config;
using Wx.ProductSearch.Domain.Sorting;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;


namespace Wx.ProductSearch.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public delegate ISortingAlgorithm ServiceResolver(SortingAlgorithm sortingAlgorithm);

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            services.Configure<ApplicationConfiguration>(Configuration);

            services.AddTransient<ISortingAlgorithmFactory, SortingAlgorithmFactory>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISortingService, SortingService>();
            services.AddTransient<IShoppingCartProcess, ShoppingCartProcess>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
