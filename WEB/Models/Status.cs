using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required]
        public string? Description { get; set; }
        public virtual ICollection<Instance>? Instances { get; set; }
    }
}
