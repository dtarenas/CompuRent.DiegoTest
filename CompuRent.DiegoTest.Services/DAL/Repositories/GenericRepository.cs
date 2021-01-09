namespace CompuRent.DiegoTest.Services.DAL.Repositories
{
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic Repository Implemenatation
    /// </summary>
    /// <seealso cref="CompuRent.DiegoTest.Services.DAL.Repositories.Facades.IGenericRepository{TEntity}" />
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly MusicRadioIncDbContext _context;

        /// <summary>
        /// The database set
        /// </summary>
        public readonly DbSet<TEntity> DBSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(MusicRadioIncDbContext context)
        {
            this._context = context;
            this.DBSet = this._context.Set<TEntity>();
        }

        /// <summary>
        /// Creates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// Task
        /// </returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            await this.DBSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task Remove(int id)
        {
            var entity = await this.DBSet.FindAsync(id);
            this._context.Remove(entity);
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Linq.IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Get()
        {
            var query = this.DBSet.AsQueryable();
            return query;
        }

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TEntity Update(TEntity entity)
        {
            this.DBSet.Attach(entity);
            this._context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
