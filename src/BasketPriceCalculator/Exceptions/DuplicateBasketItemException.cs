using System;
using System.Collections.Generic;
using System.Text;

namespace BasketPriceCalculator.Exceptions
{
    public class DuplicateBasketItemException : ArgumentException
    {
        public DuplicateBasketItemException()
        {
        }

        public DuplicateBasketItemException(string message) : base(message)
        {
        }

        public DuplicateBasketItemException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
