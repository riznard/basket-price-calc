using NUnit.Framework;
using Moq;
using BasketPriceCalculatorService = BasketPriceCalculator.Services.BasketPriceCalculator;
using BasketPriceCalculator.Repositories;
using BasketPriceCalculator.Entities;
using System.Collections.Generic;

namespace BasketPriceCalculator.Tests
{
    public class BasketPriceCalculatorTests
    {
        private BasketPriceCalculatorService _sut;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Calculate_EmptyBasket_ReturnsZeroTotal()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>()
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result  = _sut.CalculateTotal();

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Calculate_OneButterOneMilkOneBread_ReturnsNonZeroTotal()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=1 }
                    }
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(2.95m));
        }


    }
}