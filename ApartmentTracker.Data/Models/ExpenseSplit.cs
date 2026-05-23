using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("ExpenseSplits")]
    public class ExpenseSplit
    {
        [Key]
        public int SplitId { get; set; }

        [Required]
        [ForeignKey("Expense")]
        public int ExpenseId { get; set; }

        [Required]
        [ForeignKey("Resident")]
        public int ResidentUserId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SplitAmount { get; set; }

        [DataType(DataType.Currency)]
        public decimal? SplitPercentage { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Paid

        public DateTime? PaidDate { get; set; }

        [StringLength(100)]
        public string PaymentMethod { get; set; } // Cash, Transfer, Card, etc.

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public virtual Expense Expense { get; set; }
        public virtual User Resident { get; set; }

        // Navigation Properties
        public virtual System.Collections.Generic.ICollection<PaymentRecord> PaymentRecords { get; set; } = new HashSet<PaymentRecord>();
    }
}