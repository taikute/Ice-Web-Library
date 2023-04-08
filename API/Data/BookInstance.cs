using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("BookInstance")]
    public class BookInstance
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int BookCode { get; set; }
        public int StatusID { get; set; } = 1;
        [ForeignKey("StatusID")]
        public virtual BookStatus? Status { get; set; }

        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
