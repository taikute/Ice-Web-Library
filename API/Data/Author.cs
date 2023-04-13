using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Author
    {
        public int AuthorId { get; set; }
        [StringLength(30, ErrorMessage = "30 characters limited")]
        public string Name { get; set; } = "Unknow";
        [StringLength(100, ErrorMessage = "100 characters limited")]
        public string Bio { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
