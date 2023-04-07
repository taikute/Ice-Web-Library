using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Loan")]
    public class Loan
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int BookID { get; set; }
        [Required]
        public int ReaderID { get; set; }
        public DateTime BorrowedDate { get; set; } = DateTime.Now;
        public DateTime? ReturnedDate { get; set; } = null;

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; } = new Book();
        [ForeignKey("ReaderID")]
        public virtual Reader Reader { get; set; } = new Reader();
    }
}
