namespace CompuRent.DiegoTest.Presentation.Models.ViewModels
{
    using CompuRent.DiegoTest.Models.DTOs;

    /// <summary>
    /// Home Index View Model
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// Gets or sets the search dto.
        /// </summary>
        /// <value>
        /// The search dto.
        /// </value>
        public SearchDTO SearchDTO { get; set; }

        /// <summary>
        /// Gets or sets the client register dto.
        /// </summary>
        /// <value>
        /// The client register dto.
        /// </value>
        public ClientRegisterDTO  ClientRegisterDTO { get; set; }

        /// <summary>
        /// Gets or sets the login dto.
        /// </summary>
        /// <value>
        /// The login dto.
        /// </value>
        public LoginDTO LoginDTO { get; set; }
    }
}
