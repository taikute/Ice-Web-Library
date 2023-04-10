using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }

        #region Required
        [Required]
        public int AuthorID { get; set; } = 1;
        [Required]
        public int CategoryID { get; set; } = 1;
        [Required]
        public int PublisherID { get; set; } = 1;
        #endregion

        #region Nullable
        [StringLength(30)]
        public string Title { get; set; } = "Unknown";

        [StringLength(100)]
        public string Description { get; set; } = "Unknown";

        [StringLength(4, ErrorMessage = "Invalid year!")]
        public string PublishYear { get; set; } = "2023";
        public int Price { get; set; } = 1000;

        [Range(1, int.MaxValue, ErrorMessage = "Invalid quantity!")]
        public int Quantity { get; set; } = 1;
        public byte[]? CoverImage { get; set; } = null;
        public string? ContentType { get; set; } = null;

        [StringLength(10)]
        public string ISBN { get; set; } = "ISBN";
        public string Language { get; set; } = "English";
        public int PageCount { get; set; } = 1;
        public string Edition { get; set; } = "Latest Edition";
        #endregion

        public virtual ICollection<BookInstance>? BookInstances { get; set; }

        [ForeignKey("CategoryID")]
        public virtual BookCategory? BookCategory { get; set; }

        [ForeignKey("AuthorID")]
        public virtual BookAuthor? BookAuthor { get; set; }

        [ForeignKey("PublisherID")]
        public virtual BookPublisher? BookPublisher { get; set; }

    }
}
