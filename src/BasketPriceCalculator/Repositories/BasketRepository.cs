﻿using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private IList<BasketItem> items = new List<BasketItem>();
        public void Add(BasketItem item)
        {
            if (item.Product == null)
                throw new ArgumentException("Product must not be null.");
            throw new ArgumentException("Item quantity must be positive.");
        }

        public IList<BasketItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(BasketItem item)
        {
            throw new NotImplementedException();
        }
    }
}
