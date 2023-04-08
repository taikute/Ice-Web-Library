using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("BookCategory")]
    public class BookCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewCategory";
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
