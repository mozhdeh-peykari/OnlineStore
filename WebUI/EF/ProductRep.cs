using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using WebUI.Contract;

namespace WebUI.EF
{
    public class ProductRep : IProductRep
    {
        private ApplicationDbContext _dbcontext;
        public ProductRep(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Product Delete(int id)
        {
            Product p = _dbcontext.Products.FirstOrDefault(i => i.Id == id);
            if (p != null)
            {
                _dbcontext.Products.Remove(p);
                _dbcontext.SaveChanges();
            }

            return p;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbcontext.Products;
        }

        public void Save(Product product)
        {
            if(product.Id == 0)
            {
                //Add
                _dbcontext.Products.Add(product);
            }
            else
            {
                Product p = _dbcontext.Products.FirstOrDefault(i => i.Id == product.Id);
                if (p!= null)
                {
                    //Edit
                    p.Name = product.Name;
                    p.Description = product.Description;
                    p.Price = product.Price;
                    p.Category = product.Category;
                }
            }
            _dbcontext.SaveChanges();
        }
    }
}
