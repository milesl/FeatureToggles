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
    /// Features controller for interacting with feature entities
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeaturesController : BaseApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeaturesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public FeaturesController(FeatureTogglesContext context, IMapper mapper, ILogger<FeaturesController> logger) 
            : base(context, mapper, logger)
        {
        }

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>A collection of features.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
            return await this.context.Features.ToListAsync();
        }

        /// <summary>
        /// Gets a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A feature.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Feature>> GetFeature(Guid? id)
        {
            var feature = await this.context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        /// <summary>
        /// Updates a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="feature">The feature.</param>
        /// <returns>A status code representing success or failure of update.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutFeature(Guid? id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            this.context.Entry(feature).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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
        /// Creates a feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The created feature.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            this.context.Features.Add(feature);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        /// <summary>
        /// Deletes a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted feature.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Feature>> DeleteFeature(Guid? id)
        {
            var feature = await this.context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            this.context.Features.Remove(feature);
            await this.context.SaveChangesAsync();

            return feature;
        }

        /// <summary>
        /// Features the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A value indicating that the feature exists or not.</returns>
        private bool FeatureExists(Guid? id)
        {
            return this.context.Features.Any(e => e.Id == id);
        }
    }
}
