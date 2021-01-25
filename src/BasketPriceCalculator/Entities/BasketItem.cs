using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Entities
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
