using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = "NewCategory";
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
