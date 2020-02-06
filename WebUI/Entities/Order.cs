using System;
using System.Collections.Generic;
using System.Text;
using WebUI.Entities;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<BasketItem> Items { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool Shipped { get; set; }
    }
}
