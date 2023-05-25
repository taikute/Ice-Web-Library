using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;

namespace WEB.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [StringLength(30, ErrorMessage = "30 characters limited")]
        public string Name { get; set; } = "";
        [StringLength(200, ErrorMessage = "200 characters limited")] public string? Description { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
