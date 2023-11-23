using System;
using System.Collections.Generic;

namespace CustomerOrderServices.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public string CustomerId { get; set; } = null!;
        public string? Phonenumber { get; set; }
        public string? Fullname { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
