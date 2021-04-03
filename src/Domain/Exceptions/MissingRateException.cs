using System;

namespace HireMe.Domain.Exceptions
{
    public class MissingRateException : Exception
    {
        public MissingRateException(string zipCode)
    : base($"Rate for \"{zipCode}\" cannot be found.")
        {
        }
    }
}
