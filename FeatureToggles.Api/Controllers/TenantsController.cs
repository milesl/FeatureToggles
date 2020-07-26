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
    /// Tenant controller for interacting with tenant entities
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TenantsController : BaseApiController
    {
        private readonly ITenantsService tenantService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public TenantsController(ITenantsService tenantService, IMapper mapper, ILogger<TenantsController> logger)
            : base(mapper, logger)
        {
            if (tenantService == null)
            {
                throw new ArgumentNullException("tenantService");
            }

            this.tenantService = tenantService;
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns>A collection of tenants.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TenantViewModel>>> GetTenants()
        {
            var results = await this.tenantService.GetTenants();
            return this.Ok(this.mapper.Map<IEnumerable<TenantViewModel>>(results));
        }

        /// <summary>
        /// Gets a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A tenant.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TenantViewModel>> GetTenant(Guid id)
        {
            var result = await this.tenantService.GetTenant(id);
            if (result == null)
            {
                return NotFound();
            }

            return this.Ok(this.mapper.Map<TenantViewModel>(result));
        }

        /// <summary>
        /// Updates a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tenant">The tenant.</param>
        /// <returns>A status code representing success or failure of update.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTenant(Guid id, Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.tenantService.UpdateTenant(tenant);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns>The created tenant.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TenantViewModel>> PostTenant(Tenant tenant)
        {
            var result = await this.tenantService.CreateTenant(tenant);
            return CreatedAtAction("GetTenant", new { id = result.Id }, result);
        }

        /// <summary>
        /// Deletes a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted tenant.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TenantViewModel>> DeleteTenant(Guid id)
        {
            var result = await this.tenantService.DeleteTenant(id);
            return this.Ok(this.mapper.Map<TenantViewModel>(result));
        }
    }
}