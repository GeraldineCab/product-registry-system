using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProductRegistrySystem.Business.ExternalProxies.Interfaces;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Business.Utils.Constants;
using ProductRegistrySystem.Dto;

namespace ProductRegistrySystem.Business.ExternalProxies
{
    public class DiscountProxy : IDiscountProxy
    {
        private readonly IHttpClientHelper _httpClientHelper;
        private readonly IConfiguration _configuration;

        public DiscountProxy(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper ?? throw new ArgumentNullException(nameof(httpClientHelper));
        }

        /// <inheritdoc />
        public async Task<double?> GetDiscountByProductAsync(int productId, CancellationToken cancellationToken)
        {
            var discount = (await GetAllDiscountsAsync(cancellationToken)).FirstOrDefault(product => product.Id == productId);

            return discount?.Value;
        }

        /// <summary>
        /// Get all discounts
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IList<DiscountDto>> GetAllDiscountsAsync(CancellationToken cancellationToken)
        {
            var uri = $"{_configuration.GetSection(Constants.DiscountsApiConnection)}/products";
            var request = await _httpClientHelper.GetAsync(uri, cancellationToken);
            var content = await request.Content.ReadAsStringAsync(cancellationToken);

            var products = JsonSerializer.Deserialize<List<DiscountDto>>(content);
            
            return products;
        }
    }
}
