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
            var result = base.CalculateTotal();
            var basketItems = _repository.GetAll();

            var basketButterItem = basketItems.FirstOrDefault(x => x.Product.Name == "Butter");
            var basketMilkItem = basketItems.FirstOrDefault(x => x.Product.Name == "Milk");

            // consider applying the first offer
            if(basketButterItem != null)
            {
                var offerMultiplier = Math.Floor((decimal)basketButterItem.Quantity / 2.0m);
                var basketBreadItem = basketItems.FirstOrDefault(x => x.Product.Name == "Bread");

                if(basketBreadItem != null)
                {
                    int i = 0;

                    while (i < basketBreadItem.Quantity && i < offerMultiplier)
                    {
                        result -= basketBreadItem.Product.Price;
                        result += basketBreadItem.Product.Price * 0.5m;
                        i++;
                    }
                }
            }
            // consider applying the second offer
            if(basketMilkItem != null)
            {
                var offerMultiplier = Math.Floor((decimal)basketMilkItem.Quantity / 3.0m);
                var remainderMilk = basketMilkItem.Quantity - (offerMultiplier * 3);

                int i = 0;

                while (i < remainderMilk && i < offerMultiplier)
                {
                    result -= basketMilkItem.Product.Price;
                    result += basketMilkItem.Product.Price * 0.0m;
                    i++;
                }
            }
            return result;
        }
    }
}
