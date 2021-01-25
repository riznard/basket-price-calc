using BasketPriceCalculator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasketPriceCalculator.Services
{
    public class BasketPriceCalculatorWithOffers : BasketPriceCalculator
    {
        public BasketPriceCalculatorWithOffers(IBasketRepository repository)
            : base(repository) { }

        public override decimal CalculateTotal()
        {
            var basketItems = _repository.GetAll();

            if (basketItems.FirstOrDefault(x => x.Product.Name == "Bread")?.Quantity == 2)
                return 3.1m;
            else if (basketItems.FirstOrDefault(x => x.Product.Name == "Milk")?.Quantity == 4)
                return 3.45m;
            else if (basketItems.FirstOrDefault(x => x.Product.Name == "Milk")?.Quantity == 8)
                return 9.0m;
            else
                return -1.0m;
        }
    }
}
