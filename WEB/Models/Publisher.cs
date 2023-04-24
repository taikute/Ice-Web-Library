using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEB.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required, StringLength(30, ErrorMessage = "30 characters limited")] public string Name { get; set; } = "";
        [AllowNull, StringLength(200, ErrorMessage = "200 characters limited")] public string Description { get; set; }

        [AllowNull] public virtual ICollection<Book> Books { get; set; }
    }
}
