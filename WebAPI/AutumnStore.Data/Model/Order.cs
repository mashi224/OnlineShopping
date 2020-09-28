using System;
using System.Collections.Generic;

namespace AutumnStore.Data.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverAddress2 { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverState { get; set; }
        public int ReceiverZip { get; set; }

        public User User { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }

        //= new List<OrderProduct>();

    }
}
