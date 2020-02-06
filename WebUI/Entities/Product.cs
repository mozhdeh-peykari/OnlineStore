using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="برای نام مقدار وارد کنید")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage ="برای قیمت مقدار صحیح وارد کنید")]
        public double Price { get; set; }
        [Required(ErrorMessage ="دسته بندی را تعیین کنید")]
        public string Category { get; set; }
    }
}
