using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public string MerchantRef { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        /// <summary>
        /// Status value 0 when complete
        /// 1 new
        /// 2 waiting for payments
        /// -1 failed
        /// </summary>
        public int Status { get; set; }
        public string Token { get; set; }
    }
}