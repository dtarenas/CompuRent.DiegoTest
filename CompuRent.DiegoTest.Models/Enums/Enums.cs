namespace CompuRent.DiegoTest.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Search By Enum
    /// </summary>
    public enum SearchBy
    {
        /// <summary>
        /// The song
        /// </summary>
        [Display(Name = "Canción")]
        Song = 1,

        /// <summary>
        /// The album
        /// </summary>
        [Display(Name = "Álbum")]
        Album = 2
    }
}
