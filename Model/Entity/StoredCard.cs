using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class StoredCard
    {
        public int Id { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        [Required]
        public string Numbers { get; set; }
        [Required]
        public string Expiry { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
    }
}