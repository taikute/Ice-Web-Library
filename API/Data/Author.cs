using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewAuthor";
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
