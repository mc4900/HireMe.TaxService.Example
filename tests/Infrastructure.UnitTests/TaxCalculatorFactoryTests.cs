using FluentAssertions;
using HireMe.Domain.Enums;
using HireMe.Domain.Exceptions;
using HireMe.Infrastructure.Factory;
using HireMe.Infrastructure.Mapper;
using HireMe.Infrastructure.TaxApiClient.TaxJar;
using HireMe.Infrastructure.TaxApiClients.TaxSpeed;
using Moq;
using NUnit.Framework;
using System.Net.Http;

namespace HireMe.Infrastructure.UnitTests
{
    public class TaxCalculatorFactoryTests
    {
        private Mock<IHttpClientFactory> mockHttpClientFactory = new Mock<IHttpClientFactory>();
        private Mock<IEntityMapper> mockEntityMapper = new Mock<IEntityMapper>();

        [Test]
        public void TaxCalculatorFactoryShouldReturnCalculatorBasedOnSubscription()
        {
            //basic subscrption = TaxSpeed, Pro = TaxJar
            var calculatorFactory = new TaxCalculatorFactory(mockHttpClientFactory.Object, mockEntityMapper.Object);

            var subscriptionLevelBasic = SubscriptionLevel.Basic;
            var calculatorBasic = calculatorFactory.Create(subscriptionLevelBasic);
            var taxSpeedClient = new TaxSpeedClient();

            Assert.AreEqual(calculatorBasic.GetType(), taxSpeedClient.GetType());

            var subscriptionLevelPro = SubscriptionLevel.Pro;
            var calculatorPro = calculatorFactory.Create(subscriptionLevelPro);
            var taxJarClient = new TaxJarClient(mockHttpClientFactory.Object, mockEntityMapper.Object);

            Assert.AreEqual(calculatorPro.GetType(), taxJarClient.GetType());
        }


        [Test]
        public void TaxCalclatorFactoryShouldReturnNoSubscriptionExceptionWhenThereIsNoSubscription()
        {
            var calculatorFactory = new TaxCalculatorFactory(mockHttpClientFactory.Object, mockEntityMapper.Object);
            var subscriptionLevel = new SubscriptionLevel();

            FluentActions.Invoking(() => calculatorFactory.Create(subscriptionLevel)).Should().Throw<NoSubscriptionException>();

        }

    }
}
