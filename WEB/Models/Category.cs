using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(30, ErrorMessage = "30 characters limited")]
        public string Name { get; set; } = "Unknow";
        [StringLength(300, ErrorMessage = "300 characters limited")]
        public string Description { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
