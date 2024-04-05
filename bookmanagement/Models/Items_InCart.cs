using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookmanagement.Models
{
    public class Items_InCart
    {
        public Book Product { get; set; }

        public int Quantity { get; set; }
    }
}