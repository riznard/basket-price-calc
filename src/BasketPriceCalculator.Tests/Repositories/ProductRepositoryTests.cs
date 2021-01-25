using BasketPriceCalculator.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task Get_NameEmptyOrNullOrInvalid_Null(string productName)
        {
            var result = await _sut.Get(productName);

            Assert.That(result, Is.Null);
        }

        [Test]
        [TestCase("Butter")]
        [TestCase("Bread")]
        [TestCase("Milk")]
        public async Task Get_ValidName_Product(string productName)
        {
            var result = await _sut.Get(productName);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(productName));
            Assert.That(result.Price, Is.Not.Zero);
        }
    }
}
