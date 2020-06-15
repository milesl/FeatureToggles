using System;
using System.Collections.Generic;

namespace FeatureToggles.Api.ViewModels
{
    /// <summary>
    /// Tenant View Model
    /// </summary>
    public class TenantViewModel

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
        public ICollection<TenantOverrideViewModel> TenantOverrides { get; set; }
    }
}