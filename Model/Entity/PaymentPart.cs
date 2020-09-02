using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class PaymentPart
    {
        public int Id { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        public string Message { get; set; }
        public string Amount { get; set; }
        public string Numbers { get; set; }
        public string Expiry { get; set; }
        public string NameOnCard { get; set; }
        public DateTime DateAdded { get; set; }
        public string Response { get; set; }
        public string CodeId { get; set; }
    }
}