using HireMe.Domain.ValueObjects;

namespace HireMe.Domain.Entities
{
    public class Address 
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ZipCode ZipCode
        {
            get; set;

        }

    }
}
