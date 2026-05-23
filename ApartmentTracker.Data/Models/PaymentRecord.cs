using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("PaymentRecords")]
    public class PaymentRecord
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        [ForeignKey("ExpenseSplit")]
        public int SplitId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PaymentAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentMethod { get; set; } // Cash, Transfer, Card, etc.

        [StringLength(200)]
        public string TransactionReference { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public virtual ExpenseSplit ExpenseSplit { get; set; }
    }
}