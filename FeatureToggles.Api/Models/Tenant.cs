using FeatureToggles.Api.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FeatureToggles.Api.Models
{
    /// <summary>
    /// Tenant entity
    /// </summary>
    public class Tenant : ITenant

    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tenant overrides.
        /// </summary>
        /// <value>
        /// The tenant overrides.
        /// </value>
        public virtual ICollection<TenantOverride> TenantOverrides { get; set; }
    }
}