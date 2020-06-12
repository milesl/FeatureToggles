using FeatureToggles.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Controllers
{
    /// <summary>
    /// Tenant controller for interacting with tenant entities
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly FeatureTogglesContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TenantsController(FeatureTogglesContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns>A collection of tenants.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenants()
        {
            return await context.Tenants.ToListAsync();
        }

        /// <summary>
        /// Gets a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A tenant.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tenant>> GetTenant(Guid id)
        {
            var tenant = await context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            return tenant;
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

            context.Entry(tenant).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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
        /// Creates a tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns>The created tenant.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Tenant>> PostTenant(Tenant tenant)
        {
            context.Tenants.Add(tenant);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetTenant", new { id = tenant.Id }, tenant);
        }

        /// <summary>
        /// Deletes a tenant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted tenant.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Tenant>> DeleteTenant(Guid id)
        {
            var tenant = await context.Tenants.FindAsync(id);
            if (tenant == null)
            {
                return NotFound();
            }

            context.Tenants.Remove(tenant);
            await context.SaveChangesAsync();

            return tenant;
        }

        /// <summary>
        /// Tenants the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A value indicating that the tenant exists or not.</returns>

        private bool TenantExists(Guid id)
        {
            return context.Tenants.Any(e => e.Id == id);
        }
    }
}