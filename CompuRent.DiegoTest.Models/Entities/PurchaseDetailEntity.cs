namespace CompuRent.DiegoTest.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Purchase Detail Entity
    /// </summary>
    [Table("purchase_details")]
    public class PurchaseDetailEntity
    {
        /// <summary>
        /// Gets or sets the purchase detail identifier.
        /// </summary>
        /// <value>
        /// The purchase detail identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int PurchaseDetailId { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [Display(Name = "Total")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [DataType(DataType.Currency)]
        [Range(1, double.MaxValue, ErrorMessage = "{0} debe ser mayor a {1}")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the album set identifier.
        /// </summary>
        /// <value>
        /// The album set identifier.
        /// </value>
        [Display(Name = "Álbum")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        public int AlbumSetId { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        [Display(Name = "Cliente")]
        public virtual ClientEntity Client { get; set; }

        /// <summary>
        /// Gets or sets the album set.
        /// </summary>
        /// <value>
        /// The album set.
        /// </value>
        [Display(Name = "Álbum")]
        public virtual AlbumSetEntity AlbumSet { get; set; }
    }
}
