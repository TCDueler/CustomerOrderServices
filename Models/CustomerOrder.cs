using System;
using System.Collections.Generic;

namespace CustomerOrderServices.Models
{
    public partial class CustomerOrder
    {
        public string OrderId { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? StateOrder { get; set; }
        public string? DetailOrder { get; set; }
        public decimal? TotalOrder { get; set; }
        public string? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
