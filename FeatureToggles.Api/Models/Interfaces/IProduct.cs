using System;

namespace FeatureToggles.Api.Models.Interfaces
{
    /// <summary>
    /// Interface for the product entity
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
    }
}