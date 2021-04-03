using HireMe.Domain.Common;
using System.Threading.Tasks;

namespace HireMe.Service.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
