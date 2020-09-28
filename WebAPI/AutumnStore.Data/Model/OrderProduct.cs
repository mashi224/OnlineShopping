using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutumnStore.Data.Model
{
    public class OrderProduct
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public decimal ProductPrice { get; set; }

        public Order Order { get; set; }
        public Products Products { get; set; }
    }
}
