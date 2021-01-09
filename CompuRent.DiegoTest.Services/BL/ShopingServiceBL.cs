namespace CompuRent.DiegoTest.Services.BL
{
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using CompuRent.DiegoTest.Services.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Shoping Service BL Implementations
    /// </summary>
    /// <seealso cref="CompuRent.DiegoTest.Services.BL.Facades.IShopingServiceBL" />
    public class ShopingServiceBL : IShopingServiceBL
    {
        /// <summary>
        /// The purchease detail repository
        /// </summary>
        private readonly IGenericRepository<PurchaseDetailEntity> _purcheaseDetailRepository;

        /// <summary>
        /// The album set repository
        /// </summary>
        private readonly IGenericRepository<AlbumSetEntity> _albumSetRepository;

        /// <summary>
        /// The context accessor
        /// </summary>
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopingServiceBL" /> class.
        /// </summary>
        /// <param name="purcheaseDetailRepository">The purchease detail repository.</param>
        /// <param name="albumSetRepository">The album set repository.</param>
        /// <param name="contextAccessor">The context accessor.</param>
        public ShopingServiceBL(IGenericRepository<PurchaseDetailEntity> purcheaseDetailRepository, IGenericRepository<AlbumSetEntity> albumSetRepository, IHttpContextAccessor contextAccessor)
        {
            this._purcheaseDetailRepository = purcheaseDetailRepository;
            this._albumSetRepository = albumSetRepository;
            this._contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Converts to purcheasedetail.
        /// </summary>
        /// <param name="albumSetId">The album set identifier.</param>
        /// <returns></returns>
        /// <exception cref="PurchaseDetailEntity"></exception>
        public async Task<PurchaseDetailEntity> ToPurcheaseDetail(int albumSetId)
        {
            var newPurcheaseDetail = await this._albumSetRepository.Get().Where(x => x.AlbumSetId == albumSetId)
                .Select(x => new PurchaseDetailEntity()
                {
                    AlbumSetId = x.AlbumSetId,
                    ClientId = CommonHelper.Base64Decode(this._contextAccessor.HttpContext.Session.GetString("ClientId")),
                    Total = (decimal)(new Random().NextDouble() * 1000)
                })
                .FirstOrDefaultAsync();

            if (newPurcheaseDetail == null)
            {
                throw new Exception();
            }

            return newPurcheaseDetail;
        }
    }
}