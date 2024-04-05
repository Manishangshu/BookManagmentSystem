using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class Author
    {
        [Key]
        public int  id { get; set; }
        [Required(ErrorMessage ="Author name is required")]
        [Display(Name ="Author name")]
        
        public string AuthorName { get; set; }

        public virtual ICollection<Book> books { get; set; }
    }
}