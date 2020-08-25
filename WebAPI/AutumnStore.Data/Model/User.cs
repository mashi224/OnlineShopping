using System;

namespace AutumnStore.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserAddress { get; set; }
        public DateTime UserRegisteredDate { get; set; }
    }
}
