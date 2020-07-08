namespace OnlineShopping.API.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public string passwordHash { get; set; }
    }
}