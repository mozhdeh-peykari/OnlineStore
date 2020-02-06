using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Contract;

namespace WebUI.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IProductRep _productRep;
        public CategoryViewComponent(IProductRep productRep)
        {
            _productRep = productRep;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"]; //???
            return View(_productRep.GetAll().Select(x => x.Category).Distinct().OrderBy(x=>x));
        }
    }
}
