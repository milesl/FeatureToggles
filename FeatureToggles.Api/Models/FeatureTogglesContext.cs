using Microsoft.EntityFrameworkCore;
using FeatureToggles.Api.Models;

namespace FeatureToggles.Api.Models
{
    /// <summary>
    /// Db Context for the Feature Toggles Api
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class FeatureTogglesContext : DbContext
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the tenants.
        /// </summary>
        /// <value>
        /// The tenants.
        /// </value>

        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        /// <value>
        /// The features.
        /// </value>

        public DbSet<Feature> Features { get; set; }

        /// <summary>
        /// Gets or sets the tenant override.
        /// </summary>
        /// <value>
        /// The tenant override.
        /// </value>
        public DbSet<TenantOverride> TenantOverride { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureTogglesContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public FeatureTogglesContext(DbContextOptions<FeatureTogglesContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(p => p.Id);
                e.HasIndex(p => p.Name).IsUnique();
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Tenant>(e =>
            {
                e.ToTable("Tenants");
                e.HasKey(p => p.Id);
                e.HasIndex(p => p.Name).IsUnique();
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Feature>(e =>
            {
                e.ToTable("Features");
                e.HasKey(p => p.Id);
                e.HasIndex(p => p.Name);
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.Name).IsRequired().HasMaxLength(50);
                e.Property(p => p.Enabled).HasDefaultValue(false);
                e.HasOne<Product>().WithMany(p => p.Features).HasForeignKey(f => f.ProductId);
            });


            modelBuilder.Entity<TenantOverride>(e =>
            {
                e.ToTable("TenantOverrides");
                e.HasKey(p => new { p.FeatureId, p.TenantId });
                e.Property(p => p.Enabled).HasDefaultValue(false);
                e.HasOne<Feature>().WithMany(p => p.TenantOverrides).HasForeignKey(f => f.FeatureId);
                e.HasOne<Tenant>().WithMany(p => p.TenantOverrides).HasForeignKey(f => f.TenantId);
            });
        }


    }
}
