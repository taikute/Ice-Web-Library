using System.ComponentModel.DataAnnotations;

namespace API.Data
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; } = "Unknow";
        public string Description { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
