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
    /// Service for interacting with tenants
    /// </summary>
    public class TenantsService : BaseService, ITenantsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public TenantsService(FeatureTogglesContext context, ILogger<TenantsService> logger)
            : base(context, logger)
        {
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns>A collection of tenants.</returns>
        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            return await context.Tenants.ToListAsync();
        }

        /// <summary>
        /// Gets a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A tenant.</returns>
        public async Task<Tenant> GetTenant(Guid id)
        {
            return await context.Tenants.FindAsync(id);
        }

        /// <summary>
        /// Updates a tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns>The updated tenant.</returns>
        public async Task<Tenant> UpdateTenant(Tenant tenant)
        {
            if (tenant == null || !tenant.Id.HasValue)
            {
                throw new ArgumentNullException("tenant");
            }

            if (!this.TenantExists(tenant.Id.Value))
            {
                throw new NotFoundException("Tenant not found");
            }

            context.Entry(tenant).State = EntityState.Modified;
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to update tenant");
            }

            return tenant;
        }

        /// <summary>
        /// Creates a tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns>The created tenant.</returns>
        public async Task<Tenant> CreateTenant(Tenant tenant)
        {
            context.Tenants.Add(tenant);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to create tenant");
            }

            return tenant;
        }

        /// <summary>
        /// Deletes a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted tenant.</returns>
        public async Task<Tenant> DeleteTenant(Guid id)
        {
            var tenant = await context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                throw new NotFoundException("Tenant not found");
            }

            context.Tenants.Remove(tenant);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to delete tenant");
            }

            return tenant;
        }

        /// <summary>
        /// Tenants the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A value indicating that the tenant exists or not.</returns>

        public bool TenantExists(Guid id)
        {
            return context.Tenants.Any(e => e.Id == id);
        }
    }
}