using System;
using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Data.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserAddress2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public DateTime UserRegisteredDate { get; set; }
    }
}
