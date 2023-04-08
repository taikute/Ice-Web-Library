using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("BookStatus")]
    public class BookStatus
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<BookInstance>? BookInstances { get; set; }
    }
}
