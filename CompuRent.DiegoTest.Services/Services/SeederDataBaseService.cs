namespace CompuRent.DiegoTest.Services.Services
{
    using CompuRent.DiegoTest.Services.DAL;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    /// <summary>
    /// Seeder DataBase Service
    /// </summary>
    public class SeederDataBaseService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly MusicRadioIncDbContext _dbContext;

        public SeederDataBaseService(MusicRadioIncDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Seeders the database asynchronous.
        /// </summary>
        /// <returns>Seeding Database Async</returns>
        public async Task SeederDbAsync()
        {
            ////Auto Update Database Command
            await this._dbContext.Database.MigrateAsync();
        }
    }
}
