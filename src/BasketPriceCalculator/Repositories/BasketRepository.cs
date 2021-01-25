using BasketPriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            else if (item.Quantity <= 0)
                throw new ArgumentException("Item quantity must be positive.");
            else if (items.Any(x => x.Product.Name == item.Product.Name))
                throw new ArgumentException("Can't insert duplicate items.");
            items.Add(item);
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
