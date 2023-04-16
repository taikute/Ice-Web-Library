using API.Data;

namespace API.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
