using FeatureToggles.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeatureToggles.Api.Services.Interfaces
{
    public interface IFeaturesService
    {
        Task<Feature> CreateFeature(Feature feature);

        Task<Feature> DeleteFeature(Guid id);

        bool FeatureExists(Guid id);

        Task<Feature> GetFeature(Guid id);

        Task<IEnumerable<Feature>> GetFeatures();

        Task<Feature> UpdateFeature(Feature feature);
    }
}