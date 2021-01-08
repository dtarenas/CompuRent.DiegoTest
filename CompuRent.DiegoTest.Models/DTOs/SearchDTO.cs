namespace CompuRent.DiegoTest.Models.DTOs
{
    using CompuRent.DiegoTest.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Search Data Transfer Object
    /// </summary>
    public class SearchDTO
    {
        /// <summary>
        /// Gets or sets the search by.
        /// </summary>
        /// <value>
        /// The search by.
        /// </value>
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [Range(1, 2, ErrorMessage = "{0} no es válido.")]
        [Display(Name = "Buscar por")]
        public SearchBy SearchBy { get; set; }

        /// <summary>
        /// Gets or sets the query to filter.
        /// </summary>
        /// <value>
        /// The query to filter.
        /// </value>
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [MinLength(1, ErrorMessage = "{0} debe contener al menos {1} caracter")]
        [MaxLength(500, ErrorMessage = "{0} debe contener máximo {1} caracteres")]
        [Display(Name = "Digita tu filtro")]
        public string QueryToFilter { get; set; }
    }
}
