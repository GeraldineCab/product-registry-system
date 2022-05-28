using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductRegistrySystem.Api.Constants;
using ProductRegistrySystem.Business.Services.Interfaces;
using ProductRegistrySystem.Dto.Product;

namespace ProductRegistrySystem.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        /// <summary>
        /// Gets a product by its id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Found successfully!</response>
        /// <response code="404">Product not found</response>
        /// <returns></returns>
        [HttpGet]
        [Route("/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> GetProductById([FromRoute] int productId, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductById(productId, cancellationToken);

            if (product == null)
            {
                return new NotFoundObjectResult(string.Format(HttpErrorMessages.NotFoundErrorMessage, productId));
            }

            return new OkObjectResult(product);
        }
    }
}
