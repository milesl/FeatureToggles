using FeatureToggles.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Services.Interfaces
{
    public interface ITenantOverridesService
    {
        Task<TenantOverride> CreateTenantOverride(TenantOverride tenantOverride);

        Task<TenantOverride> DeleteTenantOverride(Guid tenantId, Guid featureId);

        Task<IEnumerable<TenantOverride>> GetTenantOverrides();

        Task<IEnumerable<TenantOverride>> GetTenantOverrides(Guid tenantId);

        Task<TenantOverride> UpdateTenantOverride(TenantOverride tenantOverride);
    }
}