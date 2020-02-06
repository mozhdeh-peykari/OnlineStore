using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities
{
    public class Basket
    {
        private List<BasketItem> BasketItems = new List<BasketItem>();
        public virtual IEnumerable<BasketItem> GetItems
        {
            get { return BasketItems; }
        }
        public virtual void RemoveItem(Product product)
        {
            BasketItem bi = BasketItems.Where(b => b.Product.Id == product.Id).FirstOrDefault();
            BasketItems.Remove(bi);
        }
        public virtual void Clear()
        {
            BasketItems.Clear();
        }
        public virtual double GetTotalValue()
        {
            return BasketItems.Sum(b => b.Product.Price * b.Quantity);
        }
        public virtual void AddItem(Product product, int quantity)
        {
            BasketItem item = BasketItems.Where(b => b.Product.Id == product.Id).FirstOrDefault();
            if (item != null)
            {
                item.Quantity += quantity;
            }
            else
            {
                BasketItems.Add(new BasketItem { Product = product, Quantity = quantity });
            }
        }
    }
}
