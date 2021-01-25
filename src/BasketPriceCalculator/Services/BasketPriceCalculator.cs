using BasketPriceCalculator.Repositories;
using System;
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
            return -1.0m;
        }
    }
}
