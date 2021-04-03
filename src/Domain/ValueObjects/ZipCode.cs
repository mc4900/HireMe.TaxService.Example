using HireMe.Domain.Common;
using HireMe.Domain.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HireMe.Domain.ValueObjects
{
    public class ZipCode : ValueObject
    {
        public string Value { get; }
        public ZipCode(string value)
        {
            if (!Regex.IsMatch(value, "^[0-9]{5}(?:-[0-9]{4})?$"))
                throw new InvalideZipCodeExcption(value);

            this.Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
