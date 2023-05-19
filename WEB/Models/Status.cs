using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required, StringLength(10)] public string Name { get; set; } = "";

        public virtual ICollection<Instance>? Instances { get; set; }
    }
}
