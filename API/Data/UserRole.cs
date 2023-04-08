using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("UserRole")]
    public class UserRole
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
