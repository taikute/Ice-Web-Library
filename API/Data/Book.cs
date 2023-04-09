using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }

        #region Require
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int PublisherID { get; set; }
        #endregion

        #region Nullable
        [StringLength(30)]
        public string Title { get; set; } = "Unknow";
        [StringLength(100)]
        public string Description { get; set; } = "Unknow";
        public string PublishYear { get; set; } = "2023";
        public int Price { get; set; } = 1000;
        public int Quantity { get; set; } = 1;
        public byte[]? CoverImage { get; set; }
        public string? ContentType { get; set; }
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
