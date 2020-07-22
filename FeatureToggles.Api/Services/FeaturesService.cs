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
    /// Service for interacting with features
    /// </summary>
    public class FeaturesService : BaseService, IFeaturesService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeaturesService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public FeaturesService(FeatureTogglesContext context, ILogger<FeaturesService> logger)
            : base(context, logger)
        {
        }

        /// <summary>
        /// Gets all features.
        /// </summary>
        /// <returns>A collection of Features.</returns>
        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }

        /// <summary>
        /// Gets a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A feature.</returns>
        public async Task<Feature> GetFeature(Guid id)
        {
            return await context.Features.FindAsync(id);
        }

        /// <summary>
        /// Updates a feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The updated feature.</returns>
        public async Task<Feature> UpdateFeature(Feature feature)
        {
            if (feature == null || !feature.Id.HasValue)
            {
                throw new ArgumentNullException("feature");
            }

            if (!this.FeatureExists(feature.Id.Value))
            {
                throw new NotFoundException("Feature not found");
            }

            context.Entry(feature).State = EntityState.Modified;
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to update feature");
            }

            return feature;
        }

        /// <summary>
        /// Creates a feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns>The created feature.</returns>
        public async Task<Feature> CreateFeature(Feature feature)
        {
            context.Features.Add(feature);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to create feature");
            }

            return feature;
        }

        /// <summary>
        /// Deletes a feature by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The deleted feature.</returns>
        public async Task<Feature> DeleteFeature(Guid id)
        {
            var feature = await context.Features.FindAsync(id);
            if (feature == null)
            {
                throw new NotFoundException("Feature not found");
            }

            context.Features.Remove(feature);
            int result = await context.SaveChangesAsync();
            if (result != 1)
            {
                throw new DbUpdateException("Unable to delete feature");
            }

            return feature;
        }

        /// <summary>
        /// Features the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A value indicating that the feature exists or not.</returns>

        public bool FeatureExists(Guid id)
        {
            return context.Features.Any(e => e.Id == id);
        }
    }
}