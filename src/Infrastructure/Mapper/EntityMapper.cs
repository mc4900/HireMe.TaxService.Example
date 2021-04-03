using HireMe.Domain.Entities;
using HireMe.Infrastructure.ApiClients.TaxJar.Entities;
using System.Linq;

namespace HireMe.Infrastructure.Mapper
{
    public class EntityMapper : IEntityMapper
    {  //mapping Domain Entities to non Domain Entities and vise versa can be implemented with an automapper using decorations or a custom mapper as per below
       //mapping should also have unit testing to verify entities are mapped correctly I have not included those tests in this solution
        public OrderRequest MapOrder(Order order)
        {

            return new OrderRequest()
            {
                FromZip = order.Customer.Address.ZipCode.Value,
                ToZip = order.ShippingAddress.ZipCode.Value,
                ToCountry = order.Customer.Address.Country,
                ToState = order.Customer.Address.State,
                Shipping = order.ShippingCost,
                LineItems = order.Products.Select(s => new LineItem()
                {
                    Id = s.Id,
                    Quantity = s.Quantity,
                    UnitPrice = s.Price
                }).ToList()
            };

        }


    }
}
