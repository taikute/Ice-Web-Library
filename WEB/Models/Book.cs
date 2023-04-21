using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WEB.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required] public int AuthorId { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PublisherId { get; set; }

        [AllowNull]
        [StringLength(50, ErrorMessage = "Max 50 charactor!")]
        public string Title { get; set; }

        [AllowNull]
        [StringLength(200, ErrorMessage = "Max 200 charactor!")]
        public string Description { get; set; }

        [AllowNull]
        [StringLength(4, ErrorMessage = "Invalid year!")]
        public string PublishYear { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "InvalId price!")]
        public int Price { get; set; } = 100000;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "InvalId quantity!")]
        public int Quantity { get; set; } = 1;

        [AllowNull]
        public string CoverImagePath { get; set; } = "~/1.jpg";

        [AllowNull]
        [StringLength(30)]
        public string? Language { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid page count!")]
        public int PageCount { get; set; } = 99;

        [AllowNull]
        [StringLength(30, ErrorMessage = "Max 30 charactor!")]
        public string Edition { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Instance>? Instance { get; set; }
    }
}
