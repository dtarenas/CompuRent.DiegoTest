namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.DTOs;
    using CompuRent.DiegoTest.Models.Enums;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Search Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class SearchController : Controller
    {
        /// <summary>
        /// The search service
        /// </summary>
        private readonly ISearchServiceBL _searchService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchController"/> class.
        /// </summary>
        /// <param name="searchService">The search service.</param>
        public SearchController(ISearchServiceBL searchService)
        {
            this._searchService = searchService;
        }

        /// <summary>
        /// Indexes the specified search by.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="query">The query.</param>
        /// <returns>Partial View By Search</returns>
        public async Task<IActionResult> Index(SearchDTO searchDTO)
        {
            try
            {
                switch (searchDTO.SearchBy)
                {
                    case SearchBy.Song:
                    default:
                        var songResult = this._searchService.FindBySong(searchDTO.QueryToFilter);
                        return this.PartialView("SongSetResult", await songResult.ToListAsync());
                    case SearchBy.Album:
                        var albumResult = this._searchService.FindByAlbum(searchDTO.QueryToFilter);
                        return this.PartialView("AlbumSetResult", await albumResult.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
