using HireMe.Service.Interfaces;
using HireMe.Domain.Entities;
using HireMe.Domain.ValueObjects;
using System.Threading.Tasks;

namespace HireMe.Infrastructure.TaxApiClients.TaxSpeed
{
    public class TaxSpeedClient : ITaxCalculator
    {

        //Second Mock API to show factory pattern for selecting Tax Calculator based on susbscription level of customer
        //Just returns value for simplicity
        public async Task<TaxAmount> CalculateTaxOnOrderAsync(Order order)
        {
            return await Task.Run(() => { var taxAmount = new TaxAmount(101m); return taxAmount; });
        }

        public async Task<TaxRate> GetLocationTaxRateAsync(ZipCode zipCode)
        {
            return await Task.Run(() => { var taxRate = new TaxRate(.101m); return taxRate; });
        }
    }
}
