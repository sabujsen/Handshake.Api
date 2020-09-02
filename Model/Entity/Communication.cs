using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Communication
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Specific1 { get; set; }
        public string Specific2 { get; set; }
        public string Specific3 { get; set; }
        public string Summary { get; set; }
        public DateTime DateAdded { get; set; }
        public int ConsumerId { get; set; }
        public int MerchantId { get; set; }
        public int TransactionId { get; set; }
        
    }
}