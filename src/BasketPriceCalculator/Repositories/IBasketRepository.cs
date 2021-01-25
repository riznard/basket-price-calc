using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasketPriceCalculator.Repositories
{

    public interface IBasketRepository
    {
        Task Add(BasketItem item);
        Task Remove(BasketItem item);

        // can return an empty list, but not null
        Task<IList<BasketItem>> GetAll();
    }
}
