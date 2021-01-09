namespace CompuRent.DiegoTest.Services.BL.Facades
{
    using CompuRent.DiegoTest.Models.Entities;
    using System.Linq;

    /// <summary>
    /// Search Service Interface
    /// </summary>
    public interface ISearchServiceBL
    {
        /// <summary>
        /// Finds the by album.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Albums Filtered</returns>
        IQueryable<AlbumSetEntity> FindByAlbum(string query);

        /// <summary>
        /// Finds the by song.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Song Filtered</returns>
        IQueryable<SongSetEntity> FindBySong(string query);
    }
}
