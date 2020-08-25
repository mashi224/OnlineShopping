using System;
using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Entity
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 10 characters.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
}
