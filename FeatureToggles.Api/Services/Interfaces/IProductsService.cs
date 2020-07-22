using FeatureToggles.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Services.Interfaces
{
    public interface IProductsService
    {
        Task<Product> CreateProduct(Product product);

        Task<Product> DeleteProduct(Guid id);

        Task<Product> GetProduct(Guid id);

        Task<IEnumerable<Product>> GetProducts();

        bool ProductExists(Guid id);

        Task<Product> UpdateProduct(Product product);
    }
}