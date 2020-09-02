using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public int MerchantId { get; set; }
        [Required]
        public string Mobile { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}