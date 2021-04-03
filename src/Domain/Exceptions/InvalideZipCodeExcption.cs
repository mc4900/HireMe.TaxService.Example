using System;

namespace HireMe.Domain.Exceptions
{
    public class InvalideZipCodeExcption : Exception
    {
        public InvalideZipCodeExcption(string zipCode)
              : base($"\"{zipCode}\": invalid zip code.")
        {
        }

    }
}
