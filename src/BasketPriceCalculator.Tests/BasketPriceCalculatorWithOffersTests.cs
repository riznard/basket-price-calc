using BasketPriceCalculator.Entities;
using BasketPriceCalculator.Repositories;
using BasketPriceCalculator.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BasketPriceCalculatorWithOffersService = BasketPriceCalculator.Services.BasketPriceCalculatorWithOffers;


namespace BasketPriceCalculator.Tests
{
    public class BasketPriceCalculatorWithOffersTests
    {
        private BasketPriceCalculatorWithOffers _sut;

        [Test]
        public void Calculate_TwoButterTwoBread_ReturnsNonZeroTotalWithDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=2 }
                    }
                );

            _sut = new BasketPriceCalculatorWithOffersService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(3.1m));
        }

        [Test]
        public void Calculate_FourMilk_ReturnsNonZeroTotalWithDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=4 }
                    }
                );

            _sut = new BasketPriceCalculatorWithOffersService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(3.45m));
        }

        [Test]
        public void Calculate_TwoButterOneBreadEightMilk_ReturnsNonZeroTotalWithDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=8 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=2 }

                    }
                );

            _sut = new BasketPriceCalculatorWithOffersService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(9.0m));
        }

        [Test]
        public void Calculate_OneButterOneMilkOneBread_ReturnsNonZeroTotalWithoutDiscount()
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

            _sut = new BasketPriceCalculatorWithOffersService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(2.95m));
        }

        [Test]
        public void Calculate_OneButterTwoBreadTwoMilk_ReturnsNonZeroTotalWithoutDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=1 }
                    }
                );

            _sut = new BasketPriceCalculatorWithOffersService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(5.1m));
        }

    }
}
