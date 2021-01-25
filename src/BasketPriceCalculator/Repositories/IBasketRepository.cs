using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Repositories
{
    public interface IBasketRepository
    {
        void Add(BasketItem item);
        void Remove(BasketItem item);
        IEnumerable<BasketItem> GetAll();
    }
}
