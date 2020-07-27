using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FeatureToggles.Api.Controllers
{
    /// <summary>
    /// Base Api Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseApiController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public BaseApiController(IMapper mapper, ILogger logger)
        {
            this.mapper = mapper ?? throw new ArgumentNullException("mapper");
            this.logger = logger ?? throw new ArgumentNullException("logger");
        }
    }
}