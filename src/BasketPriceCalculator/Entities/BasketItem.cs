using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Entities
{
    public class BasketItem
    {
        private int _quantity;
        public Product Product { get; set; }
        public int Quantity {
            get { return _quantity; }
            set
            {
                if (value > 0)
                    _quantity = value;
            }
        }
    }
}
