using HireMe.Domain.Entities;
using HireMe.Domain.Enums;
using HireMe.Domain.ValueObjects;
using System.Threading.Tasks;

namespace HireMe.Service.Interfaces
{
    public interface ITaxService
    {
        Task<TaxRate> GetTaxRatebyLocationAsync(Address address, SubscriptionLevel subscription);
        Task<TaxAmount> CalculateTaxOnOrderAsync(Order order);
    }
}
