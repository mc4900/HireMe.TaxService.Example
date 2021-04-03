using HireMe.Domain.Common;

namespace HireMe.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Barcode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
