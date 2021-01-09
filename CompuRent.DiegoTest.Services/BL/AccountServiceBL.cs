namespace CompuRent.DiegoTest.Services.BL
{
    using CompuRent.DiegoTest.Models.DTOs;
    using CompuRent.DiegoTest.Models.Entities;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.DAL.Repositories.Facades;
    using CompuRent.DiegoTest.Services.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    /// <summary>
    /// Account Service BL Implementatio
    /// </summary>
    /// <seealso cref="CompuRent.DiegoTest.Services.BL.Facades.IAccountServiceBL" />
    public class AccountServiceBL : IAccountServiceBL
    {
        /// <summary>
        /// The client repository
        /// </summary>
        private readonly IGenericRepository<ClientEntity> _clientRepository;

        /// <summary>
        /// The HTTP context
        /// </summary>
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountServiceBL" /> class.
        /// </summary>
        /// <param name="clientRepository">The client repository.</param>
        /// <param name="httpContext">The HTTP context.</param>
        public AccountServiceBL(IGenericRepository<ClientEntity> clientRepository, IHttpContextAccessor httpContext)
        {
            this._clientRepository = clientRepository;
            this._httpContext = httpContext;
        }

        /// <summary>
        /// Logins the specified user identifier.
        /// </summary>
        /// <param name="loginDTO">The login dto.</param>
        /// <returns>
        /// Bool control
        /// </returns>
        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            this._httpContext.HttpContext.Session.SetString("ClientId", CommonHelper.Base64Encode(loginDTO.ClientId));
            return await this._clientRepository.Get().AnyAsync(x => x.ClientId == loginDTO.ClientId && x.Password == CommonHelper.Base64Encode(loginDTO.Password));
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            this._httpContext.HttpContext.Session.Remove("ClientId");
        }

        /// <summary>
        /// Registers the new client.
        /// </summary>
        /// <param name="clientRegisterDTO">The client register dto.</param>
        /// <returns>
        /// Task
        /// </returns>
        public async Task<ClientEntity> RegisterNewClientAsync(ClientRegisterDTO clientRegisterDTO)
        {
            var newclient = CommonHelper.ToClientEntity(clientRegisterDTO);
            var client = await this._clientRepository.Add(newclient);
            await this._clientRepository.SaveChangesAsync();
            return client;
        }

        /// <summary>
        /// Users the exists asynchronous.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// Bool control
        /// </returns>
        public async Task<bool> UserExistsAsync(string clientId)
        {
            return await this._clientRepository.Get().AnyAsync(x => x.ClientId == clientId);
        }
    }
}
