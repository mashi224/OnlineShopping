using System;
using System.Collections.Generic;

namespace AutumnStore.Entity
{
    public class OrderDetailsDto
    {
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverAddress2 { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverState { get; set; }
        public int ReceiverZip { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public decimal ProductPrice { get; set; }


        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

    }
}
