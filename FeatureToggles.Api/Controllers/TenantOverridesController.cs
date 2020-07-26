using AutoMapper;
using FeatureToggles.Api.Models;
using FeatureToggles.Api.Services;
using FeatureToggles.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Controllers
{
    /// <summary>
    /// Tenant override controller for interacting with tenant override entities
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TenantOverridesController : BaseApiController
    {
        private readonly TenantOverridesService tenantOverridesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantOverridesController"/> class.
        /// </summary>
        /// <param name="tenantOverridesService">The tenant overrides service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public TenantOverridesController(TenantOverridesService tenantOverridesService, IMapper mapper, ILogger<TenantOverridesController> logger)
            : base(mapper, logger)
        {
            if (tenantOverridesService == null)
            {
                throw new ArgumentNullException("tenantOverridesService");
            }

            this.tenantOverridesService = tenantOverridesService;
        }

        /// <summary>
        /// Gets all tenant overrides.
        /// </summary>
        /// <returns>A collection of tenant overrides.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TenantOverrideViewModel>>> GetTenantOverrides()
        {
            var results = await this.tenantOverridesService.GetTenantOverrides();
            return this.Ok(this.mapper.Map<IEnumerable<TenantOverrideViewModel>>(results));
        }

        /// <summary>
        /// Gets tenant overrides by tenant identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>A collection of tenant overrides.</returns>
        [HttpGet("{tenantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TenantOverrideViewModel>>> GetTenantOverrides(Guid tenantId)
        {
            var results = await this.tenantOverridesService.GetTenantOverrides(tenantId);
            return this.Ok(this.mapper.Map<IEnumerable<TenantOverrideViewModel>>(results));
        }

        /// <summary>
        /// Updates a tenant override by tenant identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="tenantOverride">The tenant override.</param>
        /// <returns>A status code representing success or failure of update.</returns>
        [HttpPut("{tenantId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTenantOverride(Guid tenantId, TenantOverride tenantOverride)
        {
            if (tenantId != tenantOverride.TenantId)
            {
                return BadRequest();
            }

            try
            {
                await this.tenantOverridesService.UpdateTenantOverride(tenantOverride);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a tenant override.
        /// </summary>
        /// <param name="tenantOverride">The tenant override.</param>
        /// <returns>The created tenant override.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TenantOverride>> PostTenantOverride(TenantOverride tenantOverride)
        {
            return await this.tenantOverridesService.CreateTenantOverride(tenantOverride);
        }

        /// <summary>
        /// Deletes a tenant override by tenant and feature identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The deleted tenant override.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TenantOverrideViewModel>> DeleteTenantOverride(Guid tenantId, Guid featureId)
        {
            var result = await this.tenantOverridesService.DeleteTenantOverride(tenantId, featureId);
            return this.Ok(this.mapper.Map<TenantViewModel>(result));
        }

    }
}