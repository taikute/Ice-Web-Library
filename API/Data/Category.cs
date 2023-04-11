using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "Unknow";
        public string Description { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
