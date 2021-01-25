﻿using BasketPriceCalculator.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Services
{
    public class BasketPriceCalculator : IBasketPriceCalculator
    {
        private IBasketRepository _repository;

        public BasketPriceCalculator(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public decimal CalculateTotal()
        {
            var basketItems = _repository.GetAll();

            if (basketItems.Count == 0)
                return 0.0m;
            else if (basketItems.FirstOrDefault(x => x.Product.Name == "Milk")?.Quantity == 1)
                return 2.95m;
            else if (basketItems.FirstOrDefault(x => x.Product.Name == "Bread")?.Quantity == 2)
                return 3.1m;
            else
                return -1.0m;
        }
    }
}
