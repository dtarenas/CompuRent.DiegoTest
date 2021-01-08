namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.DTOs;
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Models.Enums;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Search Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class SearchController : Controller
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
        /// Initializes a new instance of the <see cref="SearchController" /> class.
        /// </summary>
        /// <param name="albumSetRepo">The album set repo.</param>
        /// <param name="songSetRepository">The song set repository.</param>
        public SearchController(IGenericRepository<AlbumSetEntity> albumSetRepo, IGenericRepository<SongSetEntity> songSetRepository)
        {
            this._albumSetRepo = albumSetRepo;
            this._songSetRepository = songSetRepository;
        }

        /// <summary>
        /// Indexes the specified search by.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="query">The query.</param>
        /// <returns>Partial View By Search</returns>
        public async Task<IActionResult> Index(SearchDTO searchDTO)
        {
            switch (searchDTO.SearchBy)
            {
                case SearchBy.Song:
                default:
                    var songResult = this._songSetRepository.Get().Where(x => EF.Functions.Like(x.Name, $"%{searchDTO.QueryToFilter}%"));
                    return this.PartialView("SongSetResult", await songResult.ToListAsync());
                case SearchBy.Album:
                    var albumResult = this._albumSetRepo.Get().Where(x => EF.Functions.Like(x.Name, $"%{searchDTO.QueryToFilter}%"));
                    return this.PartialView("AlbumSetResult", await albumResult.ToListAsync());
            }
        }
    }
}
