using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess
{
    public class OrderItems
    {
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        [Key]
        public string ProductName { get; set; }
         
    }
}
