namespace CompuRent.DiegoTest.Services.BL.Facades
{
    using CompuRent.DiegoTest.Models.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// Shoping Service BL Interface
    /// </summary>
    public interface IShopingServiceBL
    {
        /// <summary>
        /// Creates the purchease.
        /// </summary>
        /// <param name="albumSetId">The album set identifier.</param>
        /// <returns>
        /// Purchease Details Intance
        /// </returns>
        Task<PurchaseDetailEntity> ToPurcheaseDetail(int albumSetId);
    }
}
