using HireMe.Service.Interfaces;
using HireMe.Domain.Enums;
using HireMe.Domain.Exceptions;
using HireMe.Infrastructure.Mapper;
using HireMe.Infrastructure.TaxApiClient.TaxJar;
using HireMe.Infrastructure.TaxApiClients.TaxSpeed;
using System.Net.Http;

namespace HireMe.Infrastructure.Factory
{
    public class TaxCalculatorFactory : ITaxCalculateorFactory

    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IEntityMapper _mapper;
        public TaxCalculatorFactory(IHttpClientFactory httpClientFactory, IEntityMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }
        public ITaxCalculator Create(SubscriptionLevel subscriptionLevel)
        {
            switch (subscriptionLevel)
            {
                case SubscriptionLevel.Basic:
                    return new TaxSpeedClient();
                case SubscriptionLevel.Pro:
                    return new TaxJarClient(_httpClientFactory, _mapper);

            }
            throw new NoSubscriptionException();


        }
    }
}
