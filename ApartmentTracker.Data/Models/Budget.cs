using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("Budgets")]
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }

        [Required]
        public int BudgetMonth { get; set; } // 1-12

        [Required]
        public int BudgetYear { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal PlannedAmount { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal AlertThreshold { get; set; } = 80M; // Alert when spending reaches 80%

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public virtual Apartment Apartment { get; set; }
    }
}