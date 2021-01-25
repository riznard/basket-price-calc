using BasketPriceCalculator.Entities;
using BasketPriceCalculator.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Tests.Repositories
{
    public class BasketRepositoryTests
    {
        private BasketRepository _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = new BasketRepository();
        }

        [Test]
        public void Add_ZeroBasketItemQuantity_ArgumentException()
        {
            var basketItem = new BasketItem
            {
                Product = new Product { Name = "Butter", Price = 0.8m },
                Quantity = 0
            };

            Action<BasketItem> resultFunction = i => _sut.Add(i);

            Assert.That(() => resultFunction(basketItem), 
                Throws.TypeOf<ArgumentException>()
                    .With
                    .Message
                    .Contains("Item quantity must be positive."));
        }
    }
}
