using CompuRent.DiegoTest.Models.DTOs;
namespace CompuRent.DiegoTest.Services.BL.Facades
{
    using CompuRent.DiegoTest.Models.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// Account Service BL Interface
    /// </summary>
    public interface IAccountServiceBL
    {
        /// <summary>
        /// Users the exists asynchronous.
        /// </summary>
        /// <param name="clientId">The user identifier.</param>
        /// <returns>
        /// Bool control
        /// </returns>
        public Task<bool> UserExistsAsync(string clientId);

        /// <summary>
        /// Registers the new client.
        /// </summary>
        /// <param name="clientRegisterDTO">The client register dto.</param>
        /// <returns>
        /// New Client Entity
        /// </returns>
        public Task<ClientEntity> RegisterNewClientAsync(ClientRegisterDTO clientRegisterDTO);

        /// <summary>
        /// Logins the specified user identifier.
        /// </summary>
        /// <param name="loginDTO">The login dto.</param>
        /// <returns>
        /// Bool control
        /// </returns>
        public Task<bool> LoginAsync(LoginDTO loginDTO);

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout();
    }
}
