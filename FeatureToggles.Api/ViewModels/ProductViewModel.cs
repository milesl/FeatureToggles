using System;
using System.Collections.Generic;

namespace FeatureToggles.Api.ViewModels
{
    /// <summary>
    /// Product View Model
    /// </summary>
    public class ProductViewModel
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
        public ICollection<FeatureViewModel> Features { get; set; }
    }
}