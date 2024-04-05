using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        [Display(Name = "Genre name")]
        public string GenreName { get; set; }

        public virtual ICollection<Book> books { get; set; }

    }
}