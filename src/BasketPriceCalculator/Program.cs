using BasketPriceCalculator.Entities;
using BasketPriceCalculator.Exceptions;
using BasketPriceCalculator.Repositories;
using BasketPriceCalculator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BasketPriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var productRepository = provider.GetRequiredService<IProductRepository>();
            var basketRepository = provider.GetRequiredService<IBasketRepository>();
            var basketPriceCalculator = provider.GetRequiredService<IBasketPriceCalculator>();
            var basketPriceCalculatorWithOffers = provider.GetRequiredService<IBasketPriceCalculatorWithOffers>();

            var products = productRepository.GetAll().Result;

            while (true)
            {
                Console.WriteLine("Please choose (only integer):");
                var i = 1;

                foreach (var product in products)
                {
                    Console.WriteLine($"{i}. {product.Name}");
                    i++;
                }
                Console.WriteLine($"{i}. Calculate total");

                try
                {
                    var selectedOptionValue = Int32.Parse(Console.ReadLine());

                    if (selectedOptionValue == 4)
                    {
                        var basketTotalSum = basketPriceCalculatorWithOffers.CalculateTotal();
                        Console.WriteLine($"The basket total sum is: £{basketTotalSum}");
                        Console.WriteLine("Please press <enter> to exit the program.");
                        Console.ReadLine();
                        break;
                    }

                    var selectedProduct = products[selectedOptionValue - 1];

                    Console.WriteLine("Please enter the product quantity (integer):");
                    var quantity = Int32.Parse(Console.ReadLine());

                    var basketItem = new BasketItem
                    {
                        Product = selectedProduct,
                        Quantity = quantity
                    };
                    basketRepository.Add(basketItem);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Erroneous input. Please enter just the number (without the dot).");
                }
                catch (DuplicateBasketItemException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Some other bloody error.");
                }
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IProductRepository, ProductRepository>()
                            .AddSingleton<IBasketRepository, BasketRepository>()
                            .AddSingleton<IBasketPriceCalculator, BasketPriceCalculator.Services.BasketPriceCalculator>()
                            .AddSingleton<IBasketPriceCalculatorWithOffers, BasketPriceCalculatorWithOffers>()
                            );
    }
}
