using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Sms
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public string MessageID { get; set; }
        public string Modem { get; set; }
        public string Carrier { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateProcessed { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public DateTime MessageRecieved { get; set; }
        public int SmsLogId { get; set; }
    }
}