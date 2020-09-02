using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int ConsumerId { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Amount { get; set; }
        public string Tip { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
        [Required]
        public string PartA { get; set; }
        public DateTime TimeInitialised { get; set; }
        public DateTime TimeConfirmed { get; set; }
        public int Status { get; set; }
        public DateTime DateAdded { get; set; }
        /// <summary>
        /// Links payments together to allow for bill splitting
        /// </summary>
        public int TransactionId { get; set; } // default 0 for single payment
        /// <summary>
        /// Provide this so that multiple payments can occur for single 
        /// </summary>
        public string MerchantRef { get; set; }
        /// <summary>
        /// Obtained by calling /api/transactions with valid transaction
        /// </summary>
        public string TransactionToken { get; set; }
    }
}