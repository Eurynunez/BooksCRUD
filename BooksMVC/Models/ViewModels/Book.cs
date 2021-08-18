using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BooksMVC.Models.ViewModels
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "BOOKNAME")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "AUTHOR")]
        public string Autor { get; set; }
    }
}