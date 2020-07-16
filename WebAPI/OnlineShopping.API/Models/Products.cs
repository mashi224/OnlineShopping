using System;
using System.Collections.Generic;

namespace OnlineShopping.API.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage {get; set;}
        public string ProductDesc { get; set; }
        public System.Decimal ProductPrice { get; set; }
        public Category category { get; set; }
    }
}