using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class Instance
    {
        public int InstanceID { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public int StatusId { get; set; } = 1;
        public virtual Status? Status { get; set; }
        [Required]
        public string BookCode { get; set; } = "DEFAULT-CODE";
        //public virtual ICollection<Loan>? Loans { get; set; }
    }
}
