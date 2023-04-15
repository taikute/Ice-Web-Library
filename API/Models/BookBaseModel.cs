namespace API.Models
{
    public class BookBaseModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PublishYear { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        //public string? CoverImagePath { get; set; }
        public string? ISBN { get; set; }
        public string? Language { get; set; }
        public int PageCount { get; set; }
        public string? Edition { get; set; }
    }
}
