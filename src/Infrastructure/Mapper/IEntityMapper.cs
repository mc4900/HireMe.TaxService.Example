using HireMe.Domain.Entities;
using HireMe.Infrastructure.ApiClients.TaxJar.Entities;

namespace HireMe.Infrastructure.Mapper
{
    public interface IEntityMapper
    {
        OrderRequest MapOrder(Order order);
    }
}
