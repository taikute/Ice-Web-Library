namespace WEB.Models.BookModels
{
    public class BookVM
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public string? AuthorName { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
