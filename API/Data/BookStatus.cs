namespace API.Data
{
    public class BookStatus
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
