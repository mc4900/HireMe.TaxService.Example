using HireMe.Domain.Common;
using System;
using System.Collections.Generic;

namespace HireMe.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public decimal ShippingCost { get; set; }

    }
}
