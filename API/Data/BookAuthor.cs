using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewAuthor";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
