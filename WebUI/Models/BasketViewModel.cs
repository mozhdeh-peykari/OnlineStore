using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Entities;

namespace WebUI.Models
{
    public class BasketViewModel
    {
        public Basket basket { get; set; }
        public string ReturnURL { get; set; } //???
    }
}
