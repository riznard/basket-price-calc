﻿using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Repositories
{

    public interface IBasketRepository
    {
        void Add(BasketItem item);
        void Remove(BasketItem item);

        // can return an empty list, but not null
        IList<BasketItem> GetAll();
    }
}
