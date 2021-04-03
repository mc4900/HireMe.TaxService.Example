using FluentAssertions;
using HireMe.Service.Common.Exceptions;
using HireMe.Domain.Entities;
using HireMe.Domain.ValueObjects;
using HireMe.Infrastructure.ApiClients.TaxJar.Entities;
using HireMe.Infrastructure.Mapper;
using HireMe.Infrastructure.TaxApiClient.TaxJar;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HireMe.Infrastructure.UnitTests
{
    public class CalculateTaxOnOrderTest
    {
        private Order order = new Order()
        {
            Customer = new Customer()
            {
                Address = new Domain.Entities.Address()
                {
                    Country = "US",
                    State = "FL",
                    ZipCode = new ZipCode("34787")
                },
                Id = "test",
                Name = "Test Company"

            },
            ShippingAddress = new Domain.Entities.Address()
            {
                ZipCode = new ZipCode("84037"),
                Country = "US",
                State = "UT"
            },
            Products = new List<Product>()
                {

                    new Product()
                    {
                        Id = "Test",
                        Quantity = 10,
                        Price = 100.00m
                    }
                }
        };

        private Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();
        private Mock<IEntityMapper> mockMapper = new Mock<IEntityMapper>();
        private Uri testUri = new Uri("https://test.com");

        [Test]
        public async Task CalculateTaxOnOrderShouldReturnCalculatedTaxTest()
        {

            OrderResponse orderResponse = new OrderResponse()
            {
                Tax = new TaxDetail()
                {
                    AmountToCollect = 100.00m,
                    FreightTaxable = false,
                    Rate = .10m,
                    OrderTotalAmount = 1000.00m,
                    TaxableAmount = 1000.00m
                },
                Breakdown = new Breakdown()
                {
                    TaxableAmount = 1000.00m,
                    TaxCollectable = 100.00m,
                    LineItem = new LineItem()
                    {
                        Id = "1234",
                        Quantity = 100,
                        UnitPrice = 10.00m
                    }
                },
            };


            HttpResponseMessage responseMessage = new HttpResponseMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(orderResponse), Encoding.UTF8, "application/json"),
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
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            decimal expectedTaxToCollect = 100.00m;
            TaxJarClient api = new TaxJarClient(mockFactory.Object, mockMapper.Object);
            var result = await api.CalculateTaxOnOrderAsync(order);

            Assert.NotNull(result);
            Assert.IsTrue(result.Value == expectedTaxToCollect);

        }

        [Test]
        public void CalculateTaxOnOrderExceptionTest()
        {
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
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            TaxJarClient api = new TaxJarClient(mockFactory.Object, mockMapper.Object);

            FluentActions.Invoking(async () => await api.CalculateTaxOnOrderAsync(order)).Should().Throw<HttpStatusCodeException>();

        }

    }
}
