using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; } = "";
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; } = 0;
        public int Quantity { get; set; } = 1;

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; } = new Category();

        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; } = new Author();
    }
}
