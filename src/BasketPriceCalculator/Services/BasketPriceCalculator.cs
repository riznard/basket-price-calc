using BasketPriceCalculator.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Services
{
    public class BasketPriceCalculator : IBasketPriceCalculator
    {
        protected IBasketRepository _repository;

        public BasketPriceCalculator(IBasketRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual decimal CalculateTotal()
        {
            var basketItems = _repository.GetAll();
            return basketItems.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}
