using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models
{
    [Table("student_badge")]
    public class StudentBadge
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("lrn")]
        [Required]
        [MaxLength(50)]
        public string Lrn { get; set; } = string.Empty;

        [Column("badge_id")]
        public int BadgeId { get; set; }

        [Column("date_earned")]
        public DateTime DateEarned { get; set; }

        [ForeignKey("BadgeId")]
        public Badge? Badge { get; set; }
    }
}