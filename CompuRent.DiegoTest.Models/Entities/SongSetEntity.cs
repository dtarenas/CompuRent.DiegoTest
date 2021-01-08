namespace CompuRent.DiegoTest.Models.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Song Set Entity
    /// </summary>
    [Table("songs_sets")]
    public class SongSetEntity
    {
        /// <summary>
        /// Gets or sets the song set identifier.
        /// </summary>
        /// <value>
        /// The song set identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int SongSetId { get; set; }

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
        /// Gets or sets the album set identifier.
        /// </summary>
        /// <value>
        /// The album set identifier.
        /// </value>
        [Display(Name = "Álbum Set")]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        public int AlbumSetId { get; set; }

        /// <summary>
        /// Gets or sets the album set.
        /// </summary>
        /// <value>
        /// The album set.
        /// </value>
        [Display(Name = "Álbum Set")]
        public virtual AlbumSetEntity AlbumSet { get; set; }
    }
}
