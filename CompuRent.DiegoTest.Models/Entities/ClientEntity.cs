namespace CompuRent.DiegoTest.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Client Entity Class
    /// </summary>
    [Table("clients")]
    public class ClientEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientEntity"/> class.
        /// </summary>
        public ClientEntity()
        {
            this.PurchaseDetails = new HashSet<PurchaseDetailEntity>();
        }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        [Key]
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
        /// Gets or sets the purchase details.
        /// </summary>
        /// <value>
        /// The purchase details.
        /// </value>
        [Display(Name = "Detalle de la compra")]
        public ICollection<PurchaseDetailEntity> PurchaseDetails { get; set; }

    }
}
