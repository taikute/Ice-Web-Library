using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Data
{
    [Index(nameof(ISBN), IsUnique = true)]
    public class Book
    {
        public int Id { get; set; }
        [Required] public int AuthorId { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PublisherId { get; set; }
        [Required, StringLength(12, MinimumLength = 12, ErrorMessage = "ISBN must be exactly 12 characters long!")] public string ISBN { get; set; } = "ISBN";
        [Required, Range(1, int.MaxValue, ErrorMessage = "Invalid page count!")] public int PageCount { get; set; } = 99;
        [Required, Range(50000, int.MaxValue, ErrorMessage = "InvalId price!")] public int Price { get; set; } = 100000;
        [Required, Range(0, int.MaxValue, ErrorMessage = "InvalId quantity!")] public int Quantity { get; set; } = 0;
        [Required, StringLength(50, ErrorMessage = "Max 50 charactor!")] public string Title { get; set; } = "NewTitle";
        [StringLength(200, ErrorMessage = "Max 200 charactor!")] public string? Description { get; set; }
        [Required, StringLength(4, ErrorMessage = "Invalid year!")] public string? PublishYear { get; set; }
        public string? CoverImagePath { get; set; } = "~/1.jpg";
        [Required, StringLength(30)] public string Language { get; set; } = "English";
        [Required, StringLength(30, ErrorMessage = "Max 30 charactor!")] public string? Edition { get; set; }

        #region ForeignKey
        public virtual Author? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<Instance>? Instance { get; set; }
        #endregion
    }
}
