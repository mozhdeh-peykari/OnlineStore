using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contract;
using WebUI.Entities;
using WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class BasketController : Controller
    {
        private IProductRep _productRep;
        private Basket _basket;
        public BasketController(IProductRep productRep, Basket basket)
        {
            _productRep = productRep;
            _basket = basket;
        }
        // GET: /<controller>/
        public ViewResult Index(string returnUrl)
        {
            return View(new BasketViewModel() { basket = _basket ,ReturnURL=returnUrl});
        }
        public RedirectToActionResult AddToBasket(int Id, string returnUrl)
        {
            Product product = _productRep.GetAll().Where(p => p.Id == Id).FirstOrDefault();
            if (product != null)
            {
                _basket.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromBasket(int Id, string returnUrl)
        {
            Product product = _productRep.GetAll().Where(p => p.Id == Id).FirstOrDefault();
            if (product != null)
            {
                _basket.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
