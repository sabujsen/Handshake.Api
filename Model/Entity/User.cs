using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class User
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}