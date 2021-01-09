namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Song Sets Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class SongSetsController : Controller
    {
        /// <summary>
        /// The song set repository
        /// </summary>
        private readonly IGenericRepository<SongSetEntity> _songSetRepository;

        /// <summary>
        /// The album set repository
        /// </summary>
        private readonly IGenericRepository<AlbumSetEntity> _albumSetRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SongSetsController" /> class.
        /// </summary>
        /// <param name="songSetRepository">The song set repository.</param>
        /// <param name="albumSetRepository">The album set repository.</param>
        public SongSetsController(IGenericRepository<SongSetEntity> songSetRepository, IGenericRepository<AlbumSetEntity> albumSetRepository)
        {
            this._songSetRepository = songSetRepository;
            this._albumSetRepository = albumSetRepository;
        }

        // GET: SongSetEntities
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var musicRadioIncDbContext = this._songSetRepository.Get().Include(s => s.AlbumSet);
            return View(await musicRadioIncDbContext.ToListAsync());
        }

        // GET: SongSetEntities/Details/5
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

            var songSetEntity = await this._songSetRepository.Get()
                .Include(s => s.AlbumSet)
                .FirstOrDefaultAsync(m => m.SongSetId == id);
            if (songSetEntity == null)
            {
                return NotFound();
            }

            return View(songSetEntity);
        }

        // GET: SongSetEntities/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["AlbumSetId"] = new SelectList(this._albumSetRepository.Get(), "AlbumSetId", "Name");
            return View();
        }

        /// <summary>
        /// Creates the specified song set entity.
        /// </summary>
        /// <param name="songSetEntity">The song set entity.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SongSetEntity songSetEntity)
        {
            if (ModelState.IsValid)
            {
                await this._songSetRepository.Add(songSetEntity);
                await this._songSetRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AlbumSetId"] = new SelectList(this._albumSetRepository.Get(), "AlbumSetId", "Name", songSetEntity.AlbumSetId);
            return View(songSetEntity);
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

            var songSetEntity = await this._songSetRepository.Get().FirstOrDefaultAsync(x => x.SongSetId == id);
            if (songSetEntity == null)
            {
                return NotFound();
            }
            
            ViewData["AlbumSetId"] = new SelectList(this._albumSetRepository.Get(), "AlbumSetId", "Name", songSetEntity.AlbumSetId);
            return View(songSetEntity);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="songSetEntity">The song set entity.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SongSetEntity songSetEntity)
        {
            if (id != songSetEntity.SongSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._songSetRepository.Update(songSetEntity);
                    await this._songSetRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongSetEntityExists(songSetEntity.SongSetId))
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

            ViewData["AlbumSetId"] = new SelectList(this._albumSetRepository.Get(), "AlbumSetId", "Name", songSetEntity.AlbumSetId);
            return View(songSetEntity);
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

            var songSetEntity = await this._songSetRepository.Get()
                .Include(s => s.AlbumSet)
                .FirstOrDefaultAsync(m => m.SongSetId == id);
            if (songSetEntity == null)
            {
                return NotFound();
            }

            return View(songSetEntity);
        }

        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this._songSetRepository.Remove(id);
            await this._songSetRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Songs the set entity exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool SongSetEntityExists(int id)
        {
            return this._songSetRepository.Get().Any(e => e.SongSetId == id);
        }
    }
}
