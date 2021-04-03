using System;

namespace HireMe.Domain.Exceptions
{
    public class InvalidTaxAmountException : Exception
    {
        public InvalidTaxAmountException(string amount)
    : base($"\"{amount}\": amount cannot be negative.")
        {
        }
    }
}
