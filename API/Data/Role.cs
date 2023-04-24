using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Data
{
    public class Role
    {
        public int Id { get; set; }
        [AllowNull, StringLength(30, ErrorMessage = "30 characters limited!")] public string Name { get; set; }
        [AllowNull] public virtual ICollection<User> Users { get; set; }
    }
}
