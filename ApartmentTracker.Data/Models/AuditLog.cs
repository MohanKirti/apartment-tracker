using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("AuditLogs")]
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string TableName { get; set; }

        public int? RecordId { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public virtual User User { get; set; }
    }
}