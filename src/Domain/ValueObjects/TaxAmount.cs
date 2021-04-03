using HireMe.Domain.Common;
using HireMe.Domain.Exceptions;
using System.Collections.Generic;


namespace HireMe.Domain.ValueObjects
{
    public class TaxAmount : ValueObject
    {
        public decimal Value { get; }
        public TaxAmount(decimal value)
        {
            if (value < 0)
                throw new InvalidTaxAmountException(value.ToString());

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
