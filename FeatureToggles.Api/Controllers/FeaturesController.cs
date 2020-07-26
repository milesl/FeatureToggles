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
using System.Linq;
using System.Threading.Tasks;

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
        private readonly IFeaturesService featuresService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeaturesController"/> class.
        /// </summary>
        /// <param name="featuresService">The features service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public FeaturesController(IFeaturesService featuresService, IMapper mapper, ILogger<FeaturesController> logger)
            : base(mapper, logger)
        {
            if (featuresService == null)
            {
                throw new ArgumentNullException("featuresService");
            }

            this.featuresService = featuresService;
        }

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>A collection of features.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Feature>))]
        public async Task<ActionResult<IEnumerable<FeatureViewModel>>> GetFeatures()
        {
            var results = await this.featuresService.GetFeatures();
            return this.Ok(this.mapper.Map<IEnumerable<FeatureViewModel>>(results));
        }

        /// <summary>
        /// Gets a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A feature.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeatureViewModel>> GetFeature(Guid id)
        {
            var result = await this.featuresService.GetFeature(id);
            if (result == null)
            {
                return NotFound();
            }

            return this.mapper.Map<FeatureViewModel>(result);
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
        public async Task<IActionResult> PutFeature(Guid? id, FeatureViewModel feature)
        {
            var mappedFeature = this.mapper.Map<Feature>(feature);

            if (id != mappedFeature.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.featuresService.UpdateFeature(mappedFeature);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Creates a feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The created feature.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeatureViewModel))]
        public async Task<ActionResult<FeatureViewModel>> PostFeature(FeatureViewModel feature)
        {
            var mappedFeature = this.mapper.Map<Feature>(feature);
            var result = await this.featuresService.CreateFeature(mappedFeature);
            return CreatedAtAction("GetFeature", new { id = result.Id }, result);
        }

        /// <summary>
        /// Deletes a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted feature.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeatureViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeatureViewModel>> DeleteFeature(Guid id)
        {
            var result = await this.featuresService.DeleteFeature(id);
            return this.mapper.Map<FeatureViewModel>(result);
        }
    }
}