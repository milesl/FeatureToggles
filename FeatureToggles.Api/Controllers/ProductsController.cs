using AutoMapper;
using FeatureToggles.Api.Models;
using FeatureToggles.Api.Services.Interfaces;
using FeatureToggles.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Controllers
{
    /// <summary>
    /// Product controller for interacting with product entities
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IProductsService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public ProductsController(IProductsService productService, IMapper mapper, ILogger<ProductsController> logger)
            : base(mapper, logger)
        {
            if (productService == null)
            {
                throw new ArgumentNullException("productService");
            }

            this.productService = productService;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A collection of products.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductViewModel>))]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts()
        {
            var results = await this.productService.GetProducts();
            return this.Ok(this.mapper.Map<IEnumerable<ProductViewModel>>(results));
        }

        /// <summary>
        /// Gets a product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A product.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProduct(Guid id)
        {
            var result = await this.productService.GetProduct(id);
            if (result == null)
            {
                return NotFound();
            }

            return this.Ok(this.mapper.Map<ProductViewModel>(result));
        }

        /// <summary>
        /// Updates a product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="product">The product.</param>
        /// <returns>A status code representing success or failure of update.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProduct(Guid id, ProductViewModel product)
        {
            var mappedProduct = this.mapper.Map<Product>(product);

            if (id != mappedProduct.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.productService.UpdateProduct(mappedProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The created product.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductViewModel product)
        {
            var mappedProduct = this.mapper.Map<Product>(product);
            var result = await this.productService.CreateProduct(mappedProduct);
            return CreatedAtAction("GetProduct", new { id = result.Id }, result);
        }

        /// <summary>
        /// Deletes a product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted product.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> DeleteProduct(Guid id)
        {
            var result = await this.productService.DeleteProduct(id);
            return this.mapper.Map<ProductViewModel>(result); ;
        }
    }
}