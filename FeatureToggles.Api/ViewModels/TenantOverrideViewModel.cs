using System;

namespace FeatureToggles.Api.ViewModels
{
    /// <summary>
    /// Tenant Override View Model
    /// </summary>
    public class TenantOverrideViewModel
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the tenant.
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        public TenantViewModel Tenant { get; set; }

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public Guid FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the feature.
        /// </summary>
        /// <value>
        /// The feature.
        /// </value>
        public FeatureViewModel Feature { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Feature"/> is enabled for this tenant.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }
    }
}