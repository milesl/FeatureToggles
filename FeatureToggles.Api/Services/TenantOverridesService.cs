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
    /// Service for interacting with tenant override
    /// </summary>
    public class TenantOverridesService : BaseService, ITenantOverridesService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantOverridesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public TenantOverridesService(FeatureTogglesContext context, ILogger<TenantOverridesService> logger)
            : base(context, logger)
        {
        }

        /// <summary>
        /// Gets all tenantOverrides
        /// </summary>
        /// <returns>A collection of TenantOverrides</returns>
        public async Task<IEnumerable<TenantOverride>> GetTenantOverrides()
        {
            return await context.TenantOverrides.ToListAsync();
        }

        /// <summary>
        /// Gets tenant overrides by tenant identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>A collection of tenant overrides.</returns>
        public async Task<IEnumerable<TenantOverride>> GetTenantOverrides(Guid tenantId)
        {
            return await this.context.TenantOverrides.Where(to => to.TenantId == tenantId).ToListAsync();
        }

        /// <summary>
        /// Updates a tenantOverride.
        /// </summary>
        /// <param name="tenantOverride">The tenantOverride.</param>
        /// <returns>The updated tenantOverride.</returns>
        public async Task<TenantOverride> UpdateTenantOverride(TenantOverride tenantOverride)
        {
            if (tenantOverride == null)
            {
                throw new ArgumentNullException("tenantOverride");
            }

            if (!this.TenantOverrideExists(tenantOverride.TenantId, tenantOverride.FeatureId))
            {
                throw new NotFoundException("TenantOverride not found");
            }

            context.Entry(tenantOverride).State = EntityState.Modified;
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to update tenantOverride");
            }

            return tenantOverride;
        }

        /// <summary>
        /// Creates a tenantOverride.
        /// </summary>
        /// <param name="tenantOverride">The tenantOverride.</param>
        /// <returns>The created tenantOverride.</returns>
        public async Task<TenantOverride> CreateTenantOverride(TenantOverride tenantOverride)
        {
            context.TenantOverrides.Add(tenantOverride);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to create tenantOverride");
            }

            return tenantOverride;
        }

        /// <summary>
        /// Deletes a tenant override by tenant and feature identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The deleted tenant override.</returns>
        public async Task<TenantOverride> DeleteTenantOverride(Guid tenantId, Guid featureId)
        {
            var tenantOverride = await this.context.TenantOverrides.SingleOrDefaultAsync(to => to.TenantId == tenantId && to.FeatureId == featureId);
            if (tenantOverride == null)
            {
                throw new NotFoundException("TenantOverride not found");
            }

            context.TenantOverrides.Remove(tenantOverride);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to delete tenantOverride");
            }

            return tenantOverride;
        }

        /// <summary>
        /// Tenants the override exists.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>A value indicating that the tenant override exists or not.</returns>
        private bool TenantOverrideExists(Guid tenantId, Guid featureId)
        {
            return this.context.TenantOverrides.Any(to => to.TenantId == tenantId && to.FeatureId == featureId);
        }
    }
}