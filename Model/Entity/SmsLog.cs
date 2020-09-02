using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class SmsLog
    {
        public int Id { get; set; }
        public int NumberOfMessages { get; set; }
        public DateTime DateChecked { get; set; }
    }
}