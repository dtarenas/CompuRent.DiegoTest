namespace CompuRent.DiegoTest.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Login Data transfer Object
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        [Display(Name = "Doc. Identificación")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
