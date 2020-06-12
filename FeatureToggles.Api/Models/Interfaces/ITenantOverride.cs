using System;

namespace FeatureToggles.Api.Models.Interfaces
{
    /// <summary>
    /// Interface for tenant overrides
    /// </summary>
    public interface ITenantOverride
    {
        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        Guid FeatureId { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ITenantOverride"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; set; }
    }
}