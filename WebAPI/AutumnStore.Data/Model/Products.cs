using System;
using System.Collections.Generic;
using System.Text;

namespace AutumnStore.Data.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public Category category { get; set; }
    }
}
