using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Contract;
using WebUI.Models;

namespace WebUI.UI.Controllers
{
    public class ProductController: Controller
    {
        public int PSize = 4;
        private IProductRep _productRep;
        public ProductController(IProductRep productRep)
        {
            _productRep = productRep;
        }
        public ViewResult Index() {
            return View("");
        }
        public ViewResult List(string category, int page)
        {
            ProductViewModel vm = new ProductViewModel()
            {
                Products =
                    _productRep.GetAll().Where(p => p.Category == category || category == null)
                    .OrderBy(p=>p.Id)
                .Skip((page - 1) * PSize)
                .Take(PSize)
                ,
                CurrentCategory = category
                ,
                Paging = new PagingInfo()
                {
                    PageNumber = page
                    ,
                    PageSize = PSize
                    ,
                    ItemCount = _productRep.GetAll().Where(p => p.Category == category || category == null).Count()
                }
            };
            return View(vm);
        }
    }
}
