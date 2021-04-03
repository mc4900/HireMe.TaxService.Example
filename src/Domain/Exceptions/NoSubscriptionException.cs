using System;

namespace HireMe.Domain.Exceptions
{
    public class NoSubscriptionException : Exception
    {
        public NoSubscriptionException()
         : base($"Customer has no subscription.")
        {
        }
    }
}
