using FluentAssertions;
using HireMe.Domain.Exceptions;
using HireMe.Domain.ValueObjects;
using NUnit.Framework;

namespace HireMe.Domain.UnitTests.ValueObjects
{
    public class TaxRateTests
    {

        [Test]
        public void RateCannotBeGreaterThanOne()
        {
            FluentActions.Invoking(() => new TaxRate(1.5m)).Should().Throw<InvalideTaxRateException>();
        }

        [Test]
        public void RateCannotBeLessThanZero()
        {
            FluentActions.Invoking(() => new TaxRate(-1.5m)).Should().Throw<InvalideTaxRateException>();
        }


    }


}
