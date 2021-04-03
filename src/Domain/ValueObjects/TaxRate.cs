using HireMe.Domain.Common;
using HireMe.Domain.Exceptions;
using System.Collections.Generic;

namespace HireMe.Domain.ValueObjects
{
    public class TaxRate : ValueObject
    {
        public decimal Value { get; }
        public TaxRate(decimal value)
        {
            if (!(value >= 0 && value <= 1))
                throw new InvalideTaxRateException(value.ToString());

            Value = value;

        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
