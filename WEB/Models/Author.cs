using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEB.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "30 characters limited")]
        public string Name { get; set; } = string.Empty;

        [AllowNull]
        [StringLength(200, ErrorMessage = "300 characters limited")]
        public string Bio { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}