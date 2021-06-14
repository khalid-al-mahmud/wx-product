using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NSubstitute;
using Wx.ProductSearch.Application.Process;
using Wx.ProductSearch.Application.Services;
using Wx.ProductSearch.Domain.Sorting;
using Wx.ProductSearch.Interfaces;
using Wx.ProductSearch.Models;
using Xunit;

namespace Wx.ProductSearch.Tests
{
    public class ProductTests
    {

        [Fact]
        public async Task Default_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory= new SortingAlgorithmFactory();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());

            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("");

            sortedProucts.First().Name.Should().Be("Test Product D");
            sortedProucts.Last().Name.Should().Be("Test Product F");

        }

        [Fact]
        public async Task Low_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = new SortingAlgorithmFactory();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());

            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("Low");

            sortedProucts.First().Name.Should().Be("Test Product D");
            sortedProucts.Last().Name.Should().Be("Test Product F");

        }

        [Fact]
        public async Task High_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = new SortingAlgorithmFactory();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());

            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("High");

            sortedProucts.Last().Name.Should().Be("Test Product D");
            sortedProucts.First().Name.Should().Be("Test Product F");

        }


        [Fact]
        public async Task Descending_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = new SortingAlgorithmFactory();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());

            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("Descending");

            sortedProucts.First().Name.Should().Be("Test Product F");
            sortedProucts.Last().Name.Should().Be("Test Product A");

        }

        [Fact]
        public async Task Ascending_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = new SortingAlgorithmFactory();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());


            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("Ascending");

            sortedProucts.First().Name.Should().Be("Test Product A");
            sortedProucts.Last().Name.Should().Be("Test Product F");


        }

        [Fact]
        public async Task Recommended_Sort_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = new SortingAlgorithmFactory();
            
            

            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            productService.GetProducts().Returns(ProductList());
            productService.GetShopperHistory().Returns(ShoppingHistory());


            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var sortedProucts = await shoppingCartProcess.SortProducts("Recommended");

            sortedProucts.First().Name.Should().Be("Test Product A");
            sortedProucts.Last().Name.Should().Be("Test Product D");

        }


        [Fact]
        public async Task Trolly_calculate_Success()
        {
            ISortingAlgorithmFactory sortingAlgorithmFactory = Substitute.For<ISortingAlgorithmFactory>();
            IProductService productService = Substitute.For<IProductService>();
            ISortingService sortingService = new SortingService(sortingAlgorithmFactory);

            var shoppingCartProcess = new ShoppingCartProcess(productService, sortingService);
            var total = await shoppingCartProcess.CalculateShoppingCart(TrollyData());

            total.Should().Be(27.9m);
        }


        private List<Product> ProductList()
        {
            var products = new List<Product>();

            products.Add(new Product
            {
                Name = "Test Product A",
                Price = 99.99,
                Quantity = 0
            });

            products.Add(new Product
            {
                Name = "Test Product B",
                Price = 101.99,
                Quantity = 0
            });

            products.Add(new Product
            {
                Name = "Test Product C",
                Price = 10.99,
                Quantity = 0
            });

            products.Add(new Product
            {
                Name = "Test Product D",
                Price = 5,
                Quantity = 0
            });

            products.Add(new Product
            {
                Name = "Test Product F",
                Price = 999999999999,
                Quantity = 0
            });
            return products;

        }

        private List<ShopperHistory> ShoppingHistory()
        {
            var prodHistory = @"
                        [
                          {
                            'customerId': 123,
                            'products': [
                              {
                                'name': 'Test Product A',
                                'price': 99.99,
                                'quantity': 3
                              },
                              {
                                'name': 'Test Product B',
                                'price': 101.99,
                                'quantity': 1
                              },
                              {
                                'name': 'Test Product F',
                                'price': 999999999999,
                                'quantity': 1
                              }
                            ]
                          },
                          {
                            'customerId': 23,
                            'products': [
                              {
                                'name': 'Test Product A',
                                'price': 99.99,
                                'quantity': 2
                              },
                              {
                                'name': 'Test Product B',
                                'price': 101.99,
                                'quantity': 3
                              },
                              {
                                'name': 'Test Product F',
                                'price': 999999999999,
                                'quantity': 1
                              }
                            ]
                          },
                          {
                            'customerId': 23,
                            'products': [
                              {
                                'name': 'Test Product C',
                                'price': 10.99,
                                'quantity': 2
                              },
                              {
                                'name': 'Test Product F',
                                'price': 999999999999,
                                'quantity': 2
                              }
                            ]
                          },
                          {
                            'customerId': 23,
                            'products': [
                              {
                                'name': 'Test Product A',
                                'price': 99.99,
                                'quantity': 1
                              },
                              {
                                'name': 'Test Product B',
                                'price': 101.99,
                                'quantity': 1
                              },
                              {
                                'name': 'Test Product C',
                                'price': 10.99,
                                'quantity': 1
                              }
                            ]
                          }
                        ]
                        ";

            var products = JsonConvert.DeserializeObject<List<ShopperHistory>>(prodHistory);
            return products;
        }

        private Trolly TrollyData()
        {

            var trollyJson = @"{
                      'products': [
                        {
                          'name': 'product1',
                          'price': 2.3
                        },
                        {
                          'name': 'product2',
                          'price': 5.6
                        }
                        
                      ],
                      'specials': [
                        {
                          'quantities': [
                            {
                              'name': 'product1',
                              'quantity': 2
                            }
                            ,{
                              'name': 'product2',
                              'quantity':2
                            }
                          ],
                          'total': 10
                        }
                       
                      ],
                      'quantities': [
                        {
                          'name': 'product1',
                          'quantity': 5
                        },
                        {
                          'name': 'product2',
                          'quantity': 5
                        }
                      ]
                    }

                    ";

            var trolly = JsonConvert.DeserializeObject<Trolly>(trollyJson);
            return trolly;

        }
    }
}
