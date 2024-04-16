using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagement.API.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerCity { get; set; }

    }
}