using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; } // Admin, PropertyManager, Resident

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<Apartment> ManagedApartments { get; set; } = new HashSet<Apartment>();
        public virtual ICollection<ApartmentResident> ApartmentResidencies { get; set; } = new HashSet<ApartmentResident>();
        public virtual ICollection<Expense> CreatedExpenses { get; set; } = new HashSet<Expense>();
        public virtual ICollection<ExpenseSplit> ExpenseSplits { get; set; } = new HashSet<ExpenseSplit>();
        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new HashSet<AuditLog>();
    }
}