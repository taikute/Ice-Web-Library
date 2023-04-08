using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("Reader")]
    public class Reader: User
    {
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
