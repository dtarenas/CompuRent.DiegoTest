namespace CompuRent.DiegoTest.Services.DAL
{
    using CompuRent.DiegoTest.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Music Radio Inc Database Context
    /// </summary>
    public class MusicRadioIncDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicRadioIncDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public MusicRadioIncDbContext(DbContextOptions<MusicRadioIncDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>
        /// The clients.
        /// </value>
        public virtual DbSet<ClientEntity> Clients { get; set; }

        /// <summary>
        /// Gets or sets the album sets.
        /// </summary>
        /// <value>
        /// The album sets.
        /// </value>
        public virtual DbSet<AlbumSetEntity> AlbumSets { get; set; }

        /// <summary>
        /// Gets or sets the song sets.
        /// </summary>
        /// <value>
        /// The song sets.
        /// </value>
        public virtual DbSet<SongSetEntity> SongSets { get; set; }

        /// <summary>
        /// Gets or sets the purchase details.
        /// </summary>
        /// <value>
        /// The purchase details.
        /// </value>
        public virtual DbSet<PurchaseDetailEntity> PurchaseDetails { get; set; }

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
            ////Create an Unique Index for Client Id
            modelBuilder.Entity<ClientEntity>()
               .HasIndex(x => x.ClientId)
               .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
