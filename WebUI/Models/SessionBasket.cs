using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entities;
using WebUI.Infrastructures;

namespace WebUI.Models
{
    public class SessionBasket:Basket
    {
        public static Basket GetBasket(IServiceProvider serviceProvider)    //???
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket sessionBasket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            sessionBasket.Session = session;
            return sessionBasket;
        }
        [JsonIgnore] //???
        public ISession Session { get; set; }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Basket"); //???
        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session.SetJson("Basket",this); //???
        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Basket", this);
        }
        

    }
}
