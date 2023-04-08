using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public int Code { get; set; }
        public string Title { get; set; } = "NewTitle";
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int Price { get; set; } = 0;
        [Required]
        public int Quantity { get; set; } = 1;

        [ForeignKey("CategoryID")]
        public virtual BookCategory? Category { get; set; }

        [ForeignKey("AuthorID")]
        public virtual BookAuthor? Author { get; set; }
    }
}
