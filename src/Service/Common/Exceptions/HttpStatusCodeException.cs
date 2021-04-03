using System;

namespace HireMe.Service.Common.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public HttpStatusCodeException(string code)
           : base($"Api returned \"{code}\".")
        {
        }
    }
}
