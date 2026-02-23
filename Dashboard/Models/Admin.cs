using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboard.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        [Column("admin_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Column("username")]
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Column("password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}