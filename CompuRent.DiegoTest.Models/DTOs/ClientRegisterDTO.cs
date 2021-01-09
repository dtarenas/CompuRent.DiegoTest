namespace CompuRent.DiegoTest.Models.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Client Register Data Transfer Object
    /// </summary>
    public class ClientRegisterDTO
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        [Display(Name = "Doc. Identificación")]
        [MaxLength(10, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Display(Name = "Correo elecrtónico")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "{0} debe contener máximo {1} caracteres.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} no es válido.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [Display(Name = "Dirección")]
        [MaxLength(500, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(20, ErrorMessage = "{0} debe contener máximo {1} caracteres.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "{0} no es válido.")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [MaxLength(30, ErrorMessage = "{0} debe contener máximo {1} caracteres.")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [Display(Name = "Confirmar contraseña")]
        [Compare(nameof(Password), ErrorMessage = "Contraseñas no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
