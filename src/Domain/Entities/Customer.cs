using HireMe.Domain.Common;
using HireMe.Domain.Enums;

namespace HireMe.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
    }
}
