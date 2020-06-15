using System;
using System.Collections.Generic;

namespace FeatureToggles.Api.ViewModels
{
    /// <summary>
    /// Feature View Model
    /// </summary>
    public class FeatureViewModel
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
        /// Gets or sets a value indicating whether this <see cref="Feature"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public ProductViewModel Product { get; internal set; }

        /// <summary>
        /// Gets or sets the tenant overrides.
        /// </summary>
        /// <value>
        /// The tenant overrides.
        /// </value>
        public ICollection<TenantOverrideViewModel> TenantOverrides { get; set; }
    }
}