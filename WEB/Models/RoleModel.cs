
namespace WEB.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<UserModel>? Users { get; set; }
    }
}
