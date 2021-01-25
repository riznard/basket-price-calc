using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Repositories
{
    public interface IProductRepository
    {
        Product Get(string name);
    }
}
