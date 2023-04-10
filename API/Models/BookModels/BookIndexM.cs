using System.ComponentModel.DataAnnotations;

namespace API.Models.BookModels
{
    public class BookIndexM
    {
        public int ID { get; set; }
        [StringLength(30)]
        public string Title { get; set; } = "Unknown";
    }
}
