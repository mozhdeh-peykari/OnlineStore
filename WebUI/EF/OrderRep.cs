using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Contract;

namespace WebUI.EF
{
    public class OrderRep: IOrderRep
    {
        private ApplicationDbContext _dbcontext;
        public OrderRep(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Order> Orders => _dbcontext.Orders.Include(o => o.Items).ThenInclude(i => i.Product);
        public void Save(Order order)
        {
            _dbcontext.AttachRange(order.Items.Select(i => i.Product));     //???
            if (order.Id == 0)
            {
                //Add
                _dbcontext.Orders.Add(order);
            }
         
            _dbcontext.SaveChanges();
        }
    }
}

