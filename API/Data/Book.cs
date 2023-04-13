using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher? Publisher { get; set; }

        [StringLength(30)]
        public string Title { get; set; } = "Unknown";
        [StringLength(100)]
        public string Description { get; set; } = "Unknown";
        [StringLength(4, ErrorMessage = "InvalId year!")]
        public string PublishYear { get; set; } = "2023";
        [Range(0, int.MaxValue, ErrorMessage = "InvalId price!")]
        public int Price { get; set; } = 100000;
        [Range(1, int.MaxValue, ErrorMessage = "InvalId quantity!")]
        public int Quantity { get; set; } = 1;
        public string CoverImagePath { get; set; } = "~/default-book_cover_image.jpg";
        [StringLength(10)]
        public string? ISBN { get; set; } = "ISBN";
        public string? Language { get; set; } = "English";
        public int PageCount { get; set; } = 99;
        public string Edition { get; set; } = "Latest Edition";
    }
}
