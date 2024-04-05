using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate { get; set; }

        [Display(Name ="Card type")]
        public string CardType { get; set; }
        [Display(Name = "Card Number")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Invalid Card Number")]
        public long CardNumber { get; set; }
        [Display(Name = "CVV")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Invalid CVV")]
        public int CVV { get; set; }
        public decimal Amount { get; set; }
       

        //[ForeignKey("User")]
        //public int UserId { get; set; }
        
        //public string UserName { get; set; }
        
        public int OrderId { get; set; }

        //public virtual User User { get; set; }
        public virtual Order Order { get; set; }




    }
}