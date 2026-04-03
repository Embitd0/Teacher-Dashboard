using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models
{
    [Table("badge")]
    public class Badge
    {
        [Key]
        [Column("badge_id")]
        public int BadgeId { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [MaxLength(255)]
        public string? Description { get; set; }

        [Column("condition_type")]
        public string ConditionType { get; set; } = string.Empty;

        [Column("quest_id")]
        public int? QuestId { get; set; }

        [Column("required_enemies")]
        public int RequiredEnemies { get; set; } = 1;
    }
}