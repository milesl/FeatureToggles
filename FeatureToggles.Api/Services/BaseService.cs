using FeatureToggles.Api.Models;
using Microsoft.Extensions.Logging;

namespace FeatureToggles.Api.Services
{
    /// <summary>
    /// Base service implementing logging and db context
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// The db context
        /// </summary>
        protected readonly FeatureTogglesContext context;

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public BaseService(FeatureTogglesContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}