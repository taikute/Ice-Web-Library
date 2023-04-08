using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API.Data
{
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewName";
        public string Email { get; set; } = "NewEmail";
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public int RoleID { get; set; } = 1;
        [ForeignKey("RoleID")]
        public virtual UserRole? Role { get; set; }
    }
}
