using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using ProductRegistrySystem.Business.ExternalProxies;
using ProductRegistrySystem.Business.Services.Interfaces;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace ProductRegistrySystem.BusinessTests.ExternalProxies
{
    [TestFixture]
    public class DiscountProxyTests
    {
        private string _response;

        private DiscountProxy _discountProxy;
        private IHttpClientHelper _httpClientHelper;
        private IConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            _response = "[{\"productId\": 1010, \"value\": 0.44,\"id\": \"1\"}]";

            _httpClientHelper = Mock.Create<IHttpClientHelper>(Behavior.Strict);
            _configuration = SetupConfiguration();
            _discountProxy = new DiscountProxy(_httpClientHelper, _configuration);
        }

        [Test]
        public async Task Can_GetDiscountByProductAsync_When_RecordIsFound_Returns_Discount()
        {
            // Arrange
            var productId = 1010;
            _httpClientHelper.Arrange(s => s.GetAsync(Arg.AnyString, Arg.IsAny<CancellationToken>()))
                .TaskResult(
                    new HttpResponseMessage()
                    {
                        Content = new StringContent(_response),
                        StatusCode = HttpStatusCode.OK
                    });

            // Act
            var result = await _discountProxy.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0.44, result);
        }

        [Test]
        public async Task Can_GetDiscountByProductAsync_When_RecordIsNotFound_Returns_Discount()
        {
            // Arrange
            var productId = 1090;
            _httpClientHelper.Arrange(s => s.GetAsync(Arg.AnyString, Arg.IsAny<CancellationToken>()))
                .TaskResult(
                    new HttpResponseMessage()
                    {
                        Content = new StringContent(_response),
                        StatusCode = HttpStatusCode.OK
                    });

            // Act
            var result = await _discountProxy.GetDiscountByProductAsync(productId, Arg.IsAny<CancellationToken>());

            // Assert
            Assert.IsNull(result);
        }


        private IConfigurationRoot SetupConfiguration()
        {
            var keyCollection = new Dictionary<string, string> { { "ExternalConnections:DiscountApi", "https://discountapi" } };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(keyCollection)
                .Build();
        }
    }
}
