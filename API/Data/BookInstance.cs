using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("BookInstance")]
    public class BookInstance
    {
        [Key]
        public int ID { get; set; }
        public int BookID { get; set; }
        [Required]
        public string BookCode { get; set; } = "DEFAULT-CODE";
        public int StatusID { get; set; } = 1;

        [ForeignKey("StatusID")]
        public virtual BookStatus? BookStatus { get; set; }
        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }
        public virtual ICollection<Loan>? Loans { get; set; }
    }
}
