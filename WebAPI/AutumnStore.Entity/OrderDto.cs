using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Entity
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public decimal OrderTotal { get; set; }

        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverAddress2 { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverState { get; set; }
        public int ReceiverZip { get; set; }
        [Required]
        public List<OrderedProductsDto> OrderedProductsDto { get; set; }
        //public ReceiverDetailsDto ReceiverDetailsDto { get; set; }
    }
}
