namespace CompuRent.DiegoTest.Presentation.Controllers
{
    using CompuRent.DiegoTest.Models.DTOs;
    using CompuRent.DiegoTest.Services.BL.Facades;
    using CompuRent.DiegoTest.Services.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Account Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class AccountController : Controller
    {
        /// <summary>
        /// The account service bl
        /// </summary>
        private readonly IAccountServiceBL _accountServiceBL;

        /// <summary>
        /// The HTTP context
        /// </summary>
        private readonly IHttpContextAccessor _httpContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController" /> class.
        /// </summary>
        /// <param name="accountServiceBL">The account service bl.</param>
        /// <param name="httpContext">The HTTP context.</param>
        public AccountController(IAccountServiceBL accountServiceBL, IHttpContextAccessor httpContext)
        {
            this._accountServiceBL = accountServiceBL;
            this._httpContext = httpContext;
        }

        /// <summary>
        /// Logins the specified login dto.
        /// </summary>
        /// <param name="loginDTO">The login dto.</param>
        /// <returns>Login control</returns>
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            try
            {
                var loginControl = await this._accountServiceBL.LoginAsync(loginDTO);
                if (loginControl)
                {
                    this._httpContext.HttpContext.Session.SetString("ClientId", CommonHelper.Base64Encode(loginDTO.ClientId));
                    return this.RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Registers the specified client register dto.
        /// </summary>
        /// <param name="clientRegisterDTO">The client register dto.</param>
        /// <returns>Register Control</returns>
        public async Task<IActionResult> Register(ClientRegisterDTO clientRegisterDTO)
        {
            if (await this._accountServiceBL.UserExistsAsync(clientRegisterDTO.ClientId))
            {
                return this.BadRequest();
            }

            try
            {
                var newclient = await this._accountServiceBL.RegisterNewClientAsync(clientRegisterDTO);
                return this.Ok(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>Void</returns>
        public IActionResult Logout()
        {
            try
            {
                this._accountServiceBL.Logout();
                return this.RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
