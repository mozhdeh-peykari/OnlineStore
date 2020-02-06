using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Contract
{
    public interface IOrderRep
    {
        //IEnumerable<Order> GetAll();
        void Save(Order order);
       // Order Delete(int id);
    }
}
