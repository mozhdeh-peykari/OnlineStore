using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contract;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        IProductRep _productRep;
        public AdminController(IProductRep productRep)
        {
            _productRep = productRep;
        }
        public ViewResult Index()
        {
            return View(_productRep.GetAll());
        }
        public ViewResult Create()
        {

            return View("Edit", new Product());
        }
        public ViewResult Edit(int productId)
        {
            return View(_productRep.GetAll().FirstOrDefault(p => p.Id == productId));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _productRep.Save(product);
                TempData["message"] = $"{product.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = _productRep.Delete(id);
            if (p!=null)
            {
                TempData["message"] = $"{p.Name} حذف شد";
            }
            return RedirectToAction("Index");
        }
    }
}
