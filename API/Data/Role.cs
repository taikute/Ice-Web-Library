using Newtonsoft.Json;

namespace API.Data
{
    public class Role
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
