using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerManagement.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(200)]
        public string CustomerEmail { get; set; } 
        public string CustomerCity { get; set; } = string.Empty;

    }
}