namespace CompuRent.DiegoTest.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Album Set Entity
    /// </summary>
    [Table("album_sets")]
    public class AlbumSetEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumSetEntity" /> class.
        /// </summary>
        public AlbumSetEntity()
        {
            this.SongSets = new HashSet<SongSetEntity>();
            this.PurchaseDetails = new HashSet<PurchaseDetailEntity>();
        }

        /// <summary>
        /// Gets or sets the album set identifier.
        /// </summary>
        /// <value>
        /// The album set identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int AlbumSetId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MaxLength(255, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the song sets.
        /// </summary>
        /// <value>
        /// The song sets.
        /// </value>
        [Display(Name= "Lista de canciones")]
        public virtual ICollection<SongSetEntity> SongSets{ get; set; }

        /// <summary>
        /// Gets or sets the purchase details.
        /// </summary>
        /// <value>
        /// The purchase details.
        /// </value>
        [Display(Name = "Detalle de compra")]
        public virtual ICollection<PurchaseDetailEntity> PurchaseDetails { get; set; }
    }
}
