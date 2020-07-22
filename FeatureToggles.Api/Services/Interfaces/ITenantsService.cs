using FeatureToggles.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Services.Interfaces
{
    public interface ITenantsService
    {
        Task<Tenant> CreateTenant(Tenant tenant);

        Task<Tenant> DeleteTenant(Guid id);

        Task<Tenant> GetTenant(Guid id);

        Task<IEnumerable<Tenant>> GetTenants();

        bool TenantExists(Guid id);

        Task<Tenant> UpdateTenant(Tenant tenant);
    }
}