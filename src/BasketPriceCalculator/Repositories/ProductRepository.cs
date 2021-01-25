using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketPriceCalculator.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IList<Product> _products = new List<Product>
        {
            new Product {Name="Butter", Price=0.8m},
            new Product {Name="Bread", Price=1.0m},
            new Product {Name="Milk", Price=1.15m}
        };

        public Product Get(string name)
        {
            return _products.FirstOrDefault(x => x.Name == name);
        }
    }
}
