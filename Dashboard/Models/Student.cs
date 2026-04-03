using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("lrn")]
        [MaxLength(20)]
        public string Lrn { get; set; } = string.Empty;

        [Column("assigned_teacher_id")]
        public int? AssignedTeacherId { get; set; }

        [Column("username")]
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        [Column("sensory_profile_setting")]
        public string SensoryProfileSetting { get; set; } = string.Empty;

        [Column("capability_level")]
        [MaxLength(20)]
        public string? CapabilityLevel { get; set; }
    }
}