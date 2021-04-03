using HireMe.Domain.Entities;
using HireMe.Domain.ValueObjects;
using System.Threading.Tasks;

namespace HireMe.Service.Interfaces
{
    public interface ITaxCalculator
    {
        Task<TaxRate> GetLocationTaxRateAsync(ZipCode zipCode);

        Task<TaxAmount> CalculateTaxOnOrderAsync(Order order);
    }
}
