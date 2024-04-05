using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class User
    {
        [Required]
        public string Role { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastt name is required")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Key]
        public int UserId { get; set; }
        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email address Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Incorrect Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public long Phone_number { get; set; }


       public virtual ICollection<Order> Orders  { get; set; }
       
       public virtual ICollection<Payment> Payments { get; set; }

    }
}