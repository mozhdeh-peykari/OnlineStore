using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contract;
using WebUI.EF;
using WebUI.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly Basket basket;
        private readonly IOrderRep orderRep;

        public OrderController(Basket basket, IOrderRep orderRep)
        {
            this.basket = basket;
            this.orderRep = orderRep;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var count = basket.GetItems.Count();
            if (count == 0)
            {
                ModelState.AddModelError("","سبد خالی است");
            }
            if (ModelState.IsValid)
            {
                order.Items = basket.GetItems.ToList();
                orderRep.Save(order);
                return RedirectToAction("Completed");
            }
            else
                return View(order);
        }
        public IActionResult Completed()
        {
            basket.Clear();
            return View();
        }
    }
}
