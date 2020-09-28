using System;
using System.Collections.Generic;
using System.Text;

namespace AutumnStore.Entity
{
    public class OrderedProductsDto
    {
        //public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

    }
}
