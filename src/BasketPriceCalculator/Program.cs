using BasketPriceCalculator.Entities;
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

            var products = productRepository.GetAll();
            Console.WriteLine("Please select one of the following products:");
            

            /* 
            The Product property from a BasketItem should always be 
            populated via the IProductRepository implementation
            as per example below. This way we're always working with valid
            products.
            */
            var product = productRepository.Get("Butter").Result;
            var basketItem = new BasketItem { Product = product, Quantity = 1 };
            basketRepository.Add(basketItem);
            var result = basketPriceCalculator.CalculateTotal();
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
