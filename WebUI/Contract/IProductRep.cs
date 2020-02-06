using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Contract
{
    public interface IProductRep
    {
        IEnumerable<Product> GetAll();
        void Save(Product product);
        Product Delete(int id);
    }
}
