using System;

namespace HireMe.Domain.Exceptions
{
    public class InvalideTaxRateException : Exception
    {
        public InvalideTaxRateException(string rate)
            : base($"\"{rate}\": is an invalide rate. Rates must be between 0 and 1.")
        {
        }
    }
}
