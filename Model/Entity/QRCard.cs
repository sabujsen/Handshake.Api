using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class QRCard
    {
        public int Id { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        [Required]
        public string Numbers { get; set; }
        public int Status { get; set; }
        public DateTime DateAdded { get; set; }
    }
}