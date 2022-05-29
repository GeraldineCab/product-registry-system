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
        /// Gets a product by id
        /// </summary>
        /// <param name="productId">The product id</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <response code="200">Found successfully</response>
        /// <response code="404">Product not found</response>
        /// <returns></returns>
        [HttpGet]
        [Route("{productId}", Name = nameof(GetProductById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult> GetProductById([FromRoute] int productId, CancellationToken cancellationToken = default)
        {
            var product = await _productService.GetProductById(productId, cancellationToken);

            if (product == null)
            {
                return new NotFoundObjectResult(string.Format(HttpErrorMessages.NotFoundErrorMessage, productId));
            }
            
            return new OkObjectResult(product);
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="createProductDto">The create product object</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns></returns>
        /// <response code="201">Created successfully</response>
        /// <response code="400">Bad request. Input information is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDto createProductDto, CancellationToken cancellationToken = default)
        {
            var product = await _productService.CreateProductAsync(createProductDto, cancellationToken);

            return new CreatedAtRouteResult(
                nameof(GetProductById), 
                new { productId = product.Id},  
                product);
        }

        /// <summary>
        /// Updates a product information
        /// </summary>
        /// <param name="productId">The update product object</param>
        /// <param name="updateProductDto">The update product object</param>
        /// <param name="cancellationToken">Transaction cancellation token</param>
        /// <returns></returns>
        /// <response code="200">Updated successfully</response>
        /// <response code="400">Bad request. Input information is invalid</response>
        [HttpPut]
        [Route("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult> UpdateProductAsync([FromRoute] int productId, [FromBody] UpdateProductDto updateProductDto, CancellationToken cancellationToken = default)
        {
            var product = await _productService.UpdateProductAsync(productId, updateProductDto, cancellationToken);
            
            return new OkObjectResult(product);
        }
    }
}
