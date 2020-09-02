using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Merchant
    {
        public int id { get; set; }
        public string CompanyName { get; set; }
        
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string ContactName { get; set; }
        public string MerchantUserID { get; set; }
        public string MerchantPassword { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
    }
}