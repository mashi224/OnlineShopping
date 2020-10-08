using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Data.Model
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
