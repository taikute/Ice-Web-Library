using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class Instance
    {
        public int InstanceID { get; set; }
        public int BookId { get; set; }
        public int StatusId { get; set; } = 1;
        [Required] public string? ISBN { get; set; } = "ISBN";
        public virtual Book? Book { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
