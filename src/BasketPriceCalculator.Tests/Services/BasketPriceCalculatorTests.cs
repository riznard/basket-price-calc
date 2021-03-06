using NUnit.Framework;
using Moq;
using BasketPriceCalculatorService = BasketPriceCalculator.Services.BasketPriceCalculator;
using BasketPriceCalculator.Repositories;
using BasketPriceCalculator.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketPriceCalculator.Services.Tests
{
    public class BasketPriceCalculatorTests
    {
        private BasketPriceCalculatorService _sut;

        [Test]
        public void Calculate_EmptyBasket_ZeroTotal()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>())
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result  = _sut.CalculateTotal();

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void Calculate_OneButterOneMilkOneBread_NonZeroTotal()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=1 }
                    })
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(2.95m));
        }

        [Test]
        public void Calculate_OneButterTwoBreadTwoMilk_NonZeroTotal()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=1 }
                    })
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(5.1m));
        }

        [Test]
        public void Calculate_TwoButterTwoBread_NonZeroTotalWithoutDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=2 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=2 }
                    })
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(3.6m));
        }

        [Test]
        public void Calculate_FourMilk_NonZeroTotalWithoutDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=4 }
                    })
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(4.6m));
        }

        [Test]
        public void Calculate_TwoButterOneBreadEightMilk_NonZeroTotalWithoutDiscount()
        {
            var repositoryMock = new Mock<IBasketRepository>();
            repositoryMock
                .Setup(i => i.GetAll())
                .Returns(
                    Task.FromResult((IList<BasketItem>)new List<BasketItem>
                    {
                        new BasketItem { Product=new Product{ Name="Bread", Price=1.0m }, Quantity=1 },
                        new BasketItem { Product=new Product{ Name="Milk", Price=1.15m }, Quantity=8 },
                        new BasketItem { Product=new Product{ Name="Butter", Price=0.8m }, Quantity=2 }

                    })
                );

            _sut = new BasketPriceCalculatorService(repositoryMock.Object);
            var result = _sut.CalculateTotal();

            Assert.That(result, Is.EqualTo(11.8m));
        }

    }
}