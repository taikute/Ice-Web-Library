using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BookIndexModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public byte[]? CoverImage { get; set; }
        public string? ContentType { get; set; }
    }
}
