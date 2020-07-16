namespace OnlineShopping.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImage {get; set;}
        public string ProductDesc { get; set; }
        public System.Decimal ProductPrice { get; set; }
    }
}