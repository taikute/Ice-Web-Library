using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } = "NewTitle";
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int StatusID { get; set; } = 1;
        public int Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

        [ForeignKey("CategoryID")]
        public virtual BookCategory Category { get; set; } = new BookCategory();

        [ForeignKey("AuthorID")]
        public virtual BookAuthor Author { get; set; } = new BookAuthor();

        [ForeignKey("StatusID")]
        public virtual BookStatus Status { get; set; } = new BookStatus();
    }
}
