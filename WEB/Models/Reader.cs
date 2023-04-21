using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Reader : User
    {
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
