namespace WEB.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
