using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasketPriceCalculator.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(string name);

        Task<IList<Product>> GetAll();
    }
}
