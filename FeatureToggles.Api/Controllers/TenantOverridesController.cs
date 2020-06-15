using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeatureToggles.Api.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;

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
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantOverridesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public TenantOverridesController(FeatureTogglesContext context, IMapper mapper, ILogger<TenantOverridesController> logger)
            : base(context, mapper, logger)
        {
        }

        /// <summary>
        /// Gets all tenant overrides.
        /// </summary>
        /// <returns>A collection of tenant overrides.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TenantOverride>>> GetTenantOverride()
        {
            return await this.context.TenantOverride.ToListAsync();
        }

        /// <summary>
        /// Gets tenant overrides by tenant identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>A collection of tenant overrides.</returns>
        [HttpGet("{tenantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TenantOverride>>> GetTenantOverride(Guid tenantId)
        {
            var tenantOverride = await this.context.TenantOverride.Where(to => to.TenantId == tenantId).ToListAsync();

            if (tenantOverride == null)
            {
                return NotFound();
            }

            return tenantOverride;
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

            this.context.Entry(tenantOverride).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantOverrideExists(tenantOverride.TenantId, tenantOverride.FeatureId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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
            this.context.TenantOverride.Add(tenantOverride);
            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TenantOverrideExists(tenantOverride.TenantId, tenantOverride.FeatureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return tenantOverride;
        }

        /// <summary>
        /// Deletes a tenant override by tenant & feature identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns>The deleted tenant override.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TenantOverride>> DeleteTenantOverride(Guid tenantId, Guid featureId)
        {
            var tenantOverride = await this.context.TenantOverride.SingleOrDefaultAsync(to => to.TenantId == tenantId && to.FeatureId == featureId);
            if (tenantOverride == null)
            {
                return NotFound();
            }

            this.context.TenantOverride.Remove(tenantOverride);
            await this.context.SaveChangesAsync();

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
            return this.context.TenantOverride.Any(to => to.TenantId == tenantId && to.FeatureId == featureId);
        }
    }
}
