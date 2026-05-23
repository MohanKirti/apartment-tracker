using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("Apartments")]
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }

        [Required]
        [ForeignKey("PropertyManager")]
        public int PropertyManagerId { get; set; }

        [Required]
        [StringLength(200)]
        public string ApartmentName { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        public int MaxResidents { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public virtual User PropertyManager { get; set; }

        // Navigation Properties
        public virtual ICollection<ApartmentResident> Residents { get; set; } = new HashSet<ApartmentResident>();
        public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
        public virtual ICollection<Collection> Collections { get; set; } = new HashSet<Collection>();
        public virtual ICollection<Budget> Budgets { get; set; } = new HashSet<Budget>();
    }
}