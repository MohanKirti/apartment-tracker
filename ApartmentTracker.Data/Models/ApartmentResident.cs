using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("ApartmentResidents")]
    public class ApartmentResident
    {
        [Key]
        public int ResidentId { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;

        public DateTime? LeaveDate { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        // Foreign Keys
        public virtual Apartment Apartment { get; set; }
        public virtual User User { get; set; }
    }
}