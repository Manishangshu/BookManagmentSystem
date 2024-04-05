using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;
namespace bookmanagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Book name is required")]
        [Display(Name = "Book name")]
        public string BookName { get; set; }
        [Display(Name ="ISBN number")]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Invalid ISBN number")]
        public string ISBN { get; set; }
        
        [Display(Name = "Publication Date")]
        [DataType (DataType.Date)]
        [DisplayFormat(DataFormatString= "{0:yyyy-mm-dd}", ApplyFormatInEditMode =true)]
        public DateTime PublicationDate { get; set; }
        public int Price { get; set; }
        public string img {  get; set; }


        public Author Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        
        public Genre Genre { get; set; }
       

    } 
}