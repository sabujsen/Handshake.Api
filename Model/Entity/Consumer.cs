using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Consumer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }

        public List<QRCard> QRCards { get; set; }
        public List<StoredCard> StoredCards { get; set; }
    }
}