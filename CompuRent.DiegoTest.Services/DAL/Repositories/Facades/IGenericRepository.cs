namespace CompuRent.DiegoTest.Services.DAL.Repositories.Facades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Creates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task</returns>
        Task<TEntity> Create(TEntity entity);

        /// <summary>
        /// Creates the specified author.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>
        /// Task
        /// </returns>
        Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the specified author.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task Delete(int id);

        /// <summary>
        /// Deletes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        public Task SaveChangesAsync();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges();
    }
}
