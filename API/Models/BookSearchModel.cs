namespace API.Models
{
    public class BookSearchModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorModel? Author { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }
        public int PublisherId { get; set; }
        public virtual PublisherModel? Publisher { get; set; }
        public string? Title { get; set; }
    }
}
