using FluentAssertions;
using HireMe.Domain.Exceptions;
using HireMe.Domain.ValueObjects;
using NUnit.Framework;

namespace HireMe.Domain.UnitTests.ValueObjects
{
    public class TaxAmountTests
    {

        [Test]

        public void TaxAmountCannotBeNegative()
        {
            FluentActions.Invoking(() => new TaxAmount(-1m)).Should().Throw<InvalidTaxAmountException>();
        }


    }
}
