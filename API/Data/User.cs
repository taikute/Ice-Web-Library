using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "NewName";
        public string Email { get; set; } = "NewEmail";
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
    }
}
