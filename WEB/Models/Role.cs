using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "30 characters limited!")] public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
