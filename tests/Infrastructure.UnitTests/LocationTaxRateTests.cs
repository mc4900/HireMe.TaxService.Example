using FluentAssertions;
using HireMe.Service.Common.Exceptions;
using HireMe.Domain.ValueObjects;
using HireMe.Infrastructure.ApiClients.TaxJar.Entities;
using HireMe.Infrastructure.Mapper;
using HireMe.Infrastructure.TaxApiClient.TaxJar;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using HireMe.Domain.Exceptions;

namespace HireMe.Infrastructure.UnitTests
{
    public class LocationTaxRateTests
    {
        private Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();
        private Mock<IEntityMapper> mockMapper = new Mock<IEntityMapper>();
        private Uri testUri = new Uri("https://test.com");



        [Test]
        public async Task LocationTaxRatesShouldReturnRateByZipTest()
        {
            RateResponse rateResponse = new RateResponse()
            {
                CombinedRate = 0.0725m
            };


            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(rateResponse), Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = testUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxyyyzzz");
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(client);


            decimal expectedRate = 0.0725m;
            var zipCode = new ZipCode("84037");
            TaxJarClient api = new TaxJarClient(mockFactory.Object, mockMapper.Object);
            var result = await api.GetLocationTaxRateAsync(zipCode);

            Assert.NotNull(result);
            Assert.IsTrue(result.Value == expectedRate);
        }


        [Test]
        public void LocationTaxRatesHttpStatusCodeExceptionTest()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            Uri testUri = new Uri("https://test.com");
            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(string.Empty, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.BadRequest
            };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = testUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxyyyzzz");
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(client);

            var zipCode = new ZipCode("84037");

            TaxJarClient api = new TaxJarClient(mockFactory.Object, mockMapper.Object);

            FluentActions.Invoking(async () => await api.GetLocationTaxRateAsync(zipCode)).Should().Throw<HttpStatusCodeException>();
        }

        [Test]
        public void LocationTaxRatesMissingRateExceptionTest()
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            Uri testUri = new Uri("https://test.com");

            RateResponse rateResponse = new RateResponse()
            {
                CombinedRate = 0
            };

            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(rateResponse), Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage);

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = testUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "xxxyyyzzz");
            mockFactory.Setup(s => s.CreateClient(It.IsAny<string>())).Returns(client);

            var zipCode = new ZipCode("84037");

            TaxJarClient api = new TaxJarClient(mockFactory.Object, mockMapper.Object);

            FluentActions.Invoking(async () => await api.GetLocationTaxRateAsync(zipCode)).Should().Throw<MissingRateException>();

        }


    }
}
