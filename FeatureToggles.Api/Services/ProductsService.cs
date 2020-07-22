using FeatureToggles.Api.Exceptions;
using FeatureToggles.Api.Models;
using FeatureToggles.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Services
{
    /// <summary>
    /// Service for interacting with products
    /// </summary>
    public class ProductsService : BaseService, IProductsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public ProductsService(FeatureTogglesContext context, ILogger<ProductsService> logger)
            : base(context, logger)
        {
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A collection of Products</returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        /// <summary>
        /// Gets a product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A product.</returns>
        public async Task<Product> GetProduct(Guid id)
        {
            return await context.Products.FindAsync(id);
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The updated product.</returns>
        public async Task<Product> UpdateProduct(Product product)
        {
            if (product == null || !product.Id.HasValue)
            {
                throw new ArgumentNullException("product");
            }

            if (!this.ProductExists(product.Id.Value))
            {
                throw new NotFoundException("Product not found");
            }

            context.Entry(product).State = EntityState.Modified;
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to update product");
            }

            return product;
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>The created product.</returns>
        public async Task<Product> CreateProduct(Product product)
        {
            context.Products.Add(product);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to create product");
            }

            return product;
        }

        /// <summary>
        /// Deletes a product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted feature.</returns>
        public async Task<Product> DeleteProduct(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            context.Products.Remove(product);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to delete product");
            }

            return product;
        }

        /// <summary>
        /// Product the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A value indicating that the product exists or not.</returns>

        public bool ProductExists(Guid id)
        {
            return context.Products.Any(e => e.Id == id);
        }
    }
}