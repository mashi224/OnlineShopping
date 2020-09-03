using System;
using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Entity
{
    public class UserForRegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string UserEmail { get; set; }

        [Required]
        public string UserAddress { get; set; }

        public string UserAddress2 { get; set; }

        [Required]
        public string Country { get; set; }

        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 10 characters.")]
        public string Password { get; set; }

        public DateTime RegisteredDate { get; set; }
    }
}
