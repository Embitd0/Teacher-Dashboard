using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models
{
    [Table("puzzlequestscore")]
    public class PuzzleQuestScore
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("lrn")]
        [Required]
        [MaxLength(50)]
        public string Lrn { get; set; } = string.Empty;

        [Column("quest_id")]
        public int QuestId { get; set; }

        [Column("score")]
        public int Score { get; set; }

        [Column("time_on_task_sec")]
        public int TimeOnTaskSec { get; set; }

        [Column("date_started")]
        public DateTime DateStarted { get; set; }

        [Column("date_completed")]
        public DateTime DateCompleted { get; set; }
    }
}