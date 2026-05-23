using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("Collections")]
    public class Collection
    {
        [Key]
        public int CollectionId { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; } // Furniture, Electronics, Kitchen, etc.

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? PurchaseDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal? CurrentValue { get; set; }

        [StringLength(200)]
        public string Owner { get; set; } // Individual resident or "Shared"

        [Required]
        [StringLength(50)]
        public string Condition { get; set; } = "Good"; // Excellent, Good, Fair, Poor

        [StringLength(200)]
        public string Location { get; set; } // Room or area in apartment

        [StringLength(500)]
        public string Notes { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public virtual Apartment Apartment { get; set; }
    }
}