namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Purchase Details Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class PurchaseDetailsController : Controller
    {
        /// <summary>
        /// The purchease detai repository
        /// </summary>
        private readonly IGenericRepository<PurchaseDetailEntity> _purcheaseDetaiRepository;

        /// <summary>
        /// The album set repository
        /// </summary>
        private readonly IGenericRepository<AlbumSetEntity> _albumSetRepository;

        /// <summary>
        /// The shoping service bl
        /// </summary>
        private readonly IShopingServiceBL _shopingServiceBL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseDetailsController" /> class.
        /// </summary>
        /// <param name="purcheaseDetaiRepository">The purchease detai repository.</param>
        /// <param name="albumSetRepository">The album set repository.</param>
        /// <param name="shopingServiceBL">The shoping service bl.</param>
        public PurchaseDetailsController(IGenericRepository<PurchaseDetailEntity> purcheaseDetaiRepository, IGenericRepository<AlbumSetEntity> albumSetRepository, IShopingServiceBL shopingServiceBL)
        {
            this._purcheaseDetaiRepository = purcheaseDetaiRepository;
            this._albumSetRepository = albumSetRepository;
            this._shopingServiceBL = shopingServiceBL;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index View</returns>
        public async Task<IActionResult> Index()
        {
            var musicRadioIncDbContext = this._purcheaseDetaiRepository.Get().Include(p => p.AlbumSet).Include(p => p.Client);
            return View(await musicRadioIncDbContext.ToListAsync());
        }

        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Details View</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailEntity = await this._purcheaseDetaiRepository.Get()
                .Include(p => p.AlbumSet)
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.PurchaseDetailId == id);
            if (purchaseDetailEntity == null)
            {
                return NotFound();
            }

            return View(purchaseDetailEntity);
        }

        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Create By AlbumSetId</returns>
        public async Task<IActionResult> Create(int id)
        {
            try
            {
                var newPurcheaseDetail = await this._shopingServiceBL.ToPurcheaseDetail(id);
                var purcheaseCreated = await this._purcheaseDetaiRepository.Add(newPurcheaseDetail);
                await this._purcheaseDetaiRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(Details), new { id = purcheaseCreated.PurchaseDetailId });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
