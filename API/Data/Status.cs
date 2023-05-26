using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace API.Data
{
    public class Status
    {
        public int Id { get; set; }

        [Required, StringLength(20)] public string Name { get; set; } = "";

        public virtual ICollection<Instance>? Instances { get; set; }
    }
}
