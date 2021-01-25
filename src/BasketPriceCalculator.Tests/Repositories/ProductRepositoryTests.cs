using BasketPriceCalculator.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private ProductRepository _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sut = new ProductRepository();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Get_NameEmptyOrNull_Null(string productName)
        {
            var result = _sut.Get(productName);

            Assert.That(result, Is.EqualTo(null));
        }
    }
}
