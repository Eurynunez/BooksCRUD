using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksMVC.Models.ViewModels
{
    public class NewBook
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="NAME")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "AUTHOR")]
        [StringLength(50)]
        public string Autor { get; set; }
        [Required]
        [Display(Name = "CREATION DATE")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
    }
}