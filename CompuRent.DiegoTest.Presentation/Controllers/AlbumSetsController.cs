namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Album Sets Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AlbumSetsController : Controller
    {
        /// <summary>
        /// The song set repository
        /// </summary>
        private readonly IGenericRepository<AlbumSetEntity> _albumSetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumSetsController"/> class.
        /// </summary>
        /// <param name="albumSetRepository">The song set repository.</param>
        public AlbumSetsController(IGenericRepository<AlbumSetEntity> albumSetRepository)
        {
            this._albumSetRepository = albumSetRepository;
        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Song Sets View</returns>
        public async Task<IActionResult> Index()
        {
            return this.View(await this._albumSetRepository.Get().ToListAsync());
        }

        // GET: AlbumSets/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSetEntity = await this._albumSetRepository.Get().FirstOrDefaultAsync(m => m.AlbumSetId == id);
            if (albumSetEntity == null)
            {
                return NotFound();
            }

            return View(albumSetEntity);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates the specified album set entity.
        /// </summary>
        /// <param name="albumSetEntity">The album set entity.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumSetEntity albumSetEntity)
        {
            if (ModelState.IsValid)
            {
                await this._albumSetRepository.Add(albumSetEntity);
                await this._albumSetRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumSetEntity);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSetEntity = await this._albumSetRepository.Get().FirstOrDefaultAsync(x => x.AlbumSetId == id);
            if (albumSetEntity == null)
            {
                return NotFound();
            }
            return View(albumSetEntity);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="albumSetEntity">The album set entity.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlbumSetEntity albumSetEntity)
        {
            if (id != albumSetEntity.AlbumSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._albumSetRepository.Update(albumSetEntity);
                    await this._albumSetRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumSetEntityExists(albumSetEntity.AlbumSetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(albumSetEntity);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var albumSetEntity = await this._albumSetRepository.Get().FirstOrDefaultAsync(m => m.AlbumSetId == id);
            if (albumSetEntity == null)
            {
                return NotFound();
            }

            return View(albumSetEntity);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="albumSetId">The album set identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            await this._albumSetRepository.Remove(id);
            await this._albumSetRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Albums the set entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool AlbumSetEntityExists(int id)
        {
            return this._albumSetRepository.Get().Any(e => e.AlbumSetId == id);
        }
    }
}
