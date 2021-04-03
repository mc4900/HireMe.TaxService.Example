using HireMe.Domain.Entities;
using HireMe.Domain.Enums;
using HireMe.Domain.ValueObjects;
using HireMe.Infrastructure.Factory;
using HireMe.Infrastructure.Mapper;
using HireMe.Service.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HireMe.Service.UnitTests
{
    public class TaxServiceTests
    {
        private Mock<ITaxCalculateorFactory> mockTaxCalculatorFactory = new Mock<ITaxCalculateorFactory>();
        private Mock<IHttpClientFactory> mockHttpFactory = new Mock<IHttpClientFactory>();
        private Mock<IEntityMapper> mockMapper = new Mock<IEntityMapper>();

        [Test]
        public async Task TaxServiceGetTaxRateByLocationShouldReturnTaxARateTest()
        {
            var taxCalculatorFactory = new TaxCalculatorFactory(mockHttpFactory.Object,mockMapper.Object);
            var taxCalculator = taxCalculatorFactory.Create(SubscriptionLevel.Basic);
            mockTaxCalculatorFactory.Setup(s => s.Create(It.IsAny<SubscriptionLevel>())).Returns(taxCalculator);
            var taxService = new TaxService(mockTaxCalculatorFactory.Object);
           
          var address = new Address() 
          { 
             ZipCode = new ZipCode("84037")
          };
            
             var result = await taxService.GetTaxRatebyLocationAsync(address,SubscriptionLevel.Basic);
             decimal d;
            var taxRate = new TaxRate(.1m);
            Assert.IsTrue(decimal.TryParse(result.Value.ToString(), out d));
            Assert.AreEqual(result.GetType(),taxRate.GetType());
        }

        [Test]
        public async Task TaxServiceCalculateTaxOnOrderByShouldReturnATaxAmountTest()
        {
            var taxCalculatorFactory = new TaxCalculatorFactory(mockHttpFactory.Object, mockMapper.Object);
            var taxCalculator = taxCalculatorFactory.Create(SubscriptionLevel.Basic);
            mockTaxCalculatorFactory.Setup(s => s.Create(It.IsAny<SubscriptionLevel>())).Returns(taxCalculator);
            var taxService = new TaxService(mockTaxCalculatorFactory.Object);

            var address = new Address()
            {
                ZipCode = new ZipCode("84037")
            };

            var result = await taxService.GetTaxRatebyLocationAsync(address, SubscriptionLevel.Basic);
            decimal d;
            Assert.IsTrue(decimal.TryParse(result.Value.ToString(), out d));
        }


    }
   
}
