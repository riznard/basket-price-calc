using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Services
{
    public interface IBasketPriceCalculator
    {
        decimal CalculateTotal();
    }
}
