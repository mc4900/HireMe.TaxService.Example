using HireMe.Service.Interfaces;
using HireMe.Domain.Entities;
using HireMe.Domain.Enums;
using HireMe.Domain.ValueObjects;
using System.Threading.Tasks;

namespace HireMe.Service
{
    public class TaxService : ITaxService
    {
        private readonly ITaxCalculateorFactory _taxCalculatorFactory;


        public TaxService(ITaxCalculateorFactory taxCalculateorFactory)
        {
            _taxCalculatorFactory = taxCalculateorFactory;
        }

        public async Task<TaxRate> GetTaxRatebyLocationAsync(Address address, SubscriptionLevel subscription)
        {
            //tax rates rareley change should implement caching as to avoid unessary service calls
            //logging should also be implemented
            var calculator = _taxCalculatorFactory.Create(subscription);
            return await calculator.GetLocationTaxRateAsync(address.ZipCode);
            
        }

        public async Task<TaxAmount> CalculateTaxOnOrderAsync(Order order)
        {
            var calculator = _taxCalculatorFactory.Create(order.Customer.SubscriptionLevel);
            return await calculator.CalculateTaxOnOrderAsync(order);
        }
    }
}
