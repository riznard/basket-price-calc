using BasketPriceCalculator.Entities;
using BasketPriceCalculator.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasketPriceCalculator.Tests.Repositories
{
    public class BasketRepositoryTests
    {
        private BasketRepository _sut;

        [SetUp]
        public void Setup()
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

        [Test]
        public void Add_NullProduct_ArgumentException()
        {
            var basketItem = new BasketItem
            {
                Product = null,
                Quantity = 0
            };

            Action<BasketItem> resultFunction = i => _sut.Add(i);

            Assert.That(() => resultFunction(basketItem),
                Throws.TypeOf<ArgumentException>()
                    .With
                    .Message
                    .Contains("Product must not be null."));
        }

        [Test]
        public void Add_ValidProduct_NoException()
        {
            var basketItem = new BasketItem
            {
                Product = new Product { Name = "Butter", Price = 0.8m },
                Quantity = 1
            };

            var result = _sut.Add(basketItem);

            Assert.That(result, Is.EqualTo(Task.CompletedTask));
        }

        [Test]
        public void Add_ExistingProduct_ArgumentException()
        {
            var basketItem = new BasketItem
            {
                Product = new Product { Name = "Butter", Price = 0.8m },
                Quantity = 1
            };
            _sut.Add(basketItem);

            Action<BasketItem> resultFunction = i => _sut.Add(i);

            Assert.That(() => resultFunction(basketItem),
                Throws.TypeOf<ArgumentException>()
                    .With
                    .Message
                    .Contains("Can't insert duplicate items."));
        }
    }
}
