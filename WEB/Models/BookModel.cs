namespace WEB.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public virtual AuthorModel? Author { get; set; }
        public virtual CategoryModel? Category { get; set; }
        public virtual PublisherModel? Publisher { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PublishYear { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string? CoverImagePath { get; set; }
        public string? ISBN { get; set; }
        public string? Language { get; set; }
        public int PageCount { get; set; }
        public string? Edition { get; set; }
    }
}
