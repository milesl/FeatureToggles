using FeatureToggles.Api.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FeatureToggles.Api.Models
{
    /// <summary>
    /// Product entity
    /// </summary>
    /// <seealso cref="FeatureToggles.Api.Models.Interfaces.IProduct" />
    public class Product : IProduct
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
        /// Gets or sets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>
        public virtual ICollection<Feature> Features { get; set; }
    }
}