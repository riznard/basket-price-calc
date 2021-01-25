using BasketPriceCalculator.Entities;
using BasketPriceCalculator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketPriceCalculator.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private IList<BasketItem> _items = new List<BasketItem>();
        public Task Add(BasketItem item)
        {
            if (item.Product == null)
                throw new ArgumentException("Product must not be null.");
            else if (item.Quantity <= 0)
                throw new ArgumentException("Item quantity must be positive.");
            else if (_items.Any(x => x.Product.Name == item.Product.Name))
                throw new DuplicateBasketItemException("This item is already in the basket.");

            _items.Add(item);
            return Task.CompletedTask;
        }

        public Task<IList<BasketItem>> GetAll()
        {
            return Task.FromResult(_items);
        }

        public Task Remove(BasketItem item)
        {
            if (!_items.Any(x => x.Product.Name == item.Product.Name))
                throw new ArgumentException("This item doesn't exist");

            _items.Remove(item);
            return Task.CompletedTask;
        }
    }
}
