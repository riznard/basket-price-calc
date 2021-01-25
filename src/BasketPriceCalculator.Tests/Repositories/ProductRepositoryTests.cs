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
        [TestCase("invalidName")]
        public void Get_NameEmptyOrNullOrInvalid_Null(string productName)
        {
            var result = _sut.Get(productName);

            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        [TestCase("Butter")]
        [TestCase("Bread")]
        [TestCase("Milk")]
        public void Get_ValidName_Product(string productName)
        {
            var result = _sut.Get(productName);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(productName));
            Assert.That(result.Price, Is.Not.Zero);
        }
    }
}
