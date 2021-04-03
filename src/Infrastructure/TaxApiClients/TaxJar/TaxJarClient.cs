using HireMe.Service.Common.Exceptions;
using HireMe.Service.Interfaces;
using HireMe.Domain.Entities;
using HireMe.Domain.ValueObjects;
using HireMe.Infrastructure.ApiClients.TaxJar.Entities;
using HireMe.Infrastructure.Mapper;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HireMe.Domain.Exceptions;

namespace HireMe.Infrastructure.TaxApiClient.TaxJar
{
    public class TaxJarClient : ITaxCalculator
    {
        private IHttpClientFactory _httpClientFactory;
        private IEntityMapper _entityMapper;
        //needs logging and caching. 
        public TaxJarClient(IHttpClientFactory httpClientFactory, IEntityMapper entityMapper)
        {
            _httpClientFactory = httpClientFactory;
            _entityMapper = entityMapper;
        }


        public async Task<TaxRate> GetLocationTaxRateAsync(ZipCode zipCode)
        {
            var client = _httpClientFactory.CreateClient("TaxJarApi");
            var request = new HttpRequestMessage(HttpMethod.Get, "/rates/" + zipCode.Value);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<RateResponse>(stream);
                return result.CombinedRate == 0 ? throw new MissingRateException(zipCode.ToString()) : new TaxRate(result.CombinedRate);
            }

            throw new HttpStatusCodeException(response.StatusCode.ToString());


        }

        public async Task<Domain.ValueObjects.TaxAmount> CalculateTaxOnOrderAsync(Order order)
        {
            var orderRequset = _entityMapper.MapOrder(order);
            var client = _httpClientFactory.CreateClient("TaxJarApi");
            var requestBody = JsonSerializer.Serialize(orderRequset);
            var request = new HttpRequestMessage(HttpMethod.Post, "/taxes");
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<OrderResponse>(stream);
                return new Domain.ValueObjects.TaxAmount(result.Tax.AmountToCollect);
            }

            throw new HttpStatusCodeException(response.StatusCode.ToString());

        }
    }
}
