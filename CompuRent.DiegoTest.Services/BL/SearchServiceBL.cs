namespace CompuRent.DiegoTest.Services.BL
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    /// <summary>
    /// Search Service Implementation
    /// </summary>
    /// <seealso cref="CompuRent.DiegoTest.Services.BL.Facades.ISearchServiceBL" />
    public class SearchServiceBL : ISearchServiceBL
    {
        /// <summary>
        /// The album set repo
        /// </summary>
        private readonly IGenericRepository<AlbumSetEntity> _albumSetRepo;

        /// <summary>
        /// The song set repository
        /// </summary>
        private readonly IGenericRepository<SongSetEntity> _songSetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchServiceBL"/> class.
        /// </summary>
        /// <param name="albumSetRepo">The album set repo.</param>
        /// <param name="songSetRepository">The song set repository.</param>
        public SearchServiceBL(IGenericRepository<AlbumSetEntity> albumSetRepo, IGenericRepository<SongSetEntity> songSetRepository)
        {
            this._albumSetRepo = albumSetRepo;
            this._songSetRepository = songSetRepository;
        }

        /// <summary>
        /// Finds the by album.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Albums Filtered
        /// </returns>
        public IQueryable<AlbumSetEntity> FindByAlbum(string query)
        {
            var albumResult = this._albumSetRepo.Get().Where(x => EF.Functions.Like(x.Name.ToUpper(), $"%{query.ToUpper()}%"));
            return albumResult;
        }

        /// <summary>
        /// Finds the by song.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Song Filtered
        /// </returns>
        public IQueryable<SongSetEntity> FindBySong(string query)
        {
            var songResult = this._songSetRepository.Get().Where(x => EF.Functions.Like(x.Name.ToUpper(), $"%{query.ToUpper()}%")).Include(x => x.AlbumSet);
            return songResult;
        }
    }
}
