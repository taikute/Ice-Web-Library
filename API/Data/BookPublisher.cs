namespace API.Data
{
    public class BookPublisher
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Unknow";
        public string Description { get; set; } = "Unknow";
        public virtual ICollection<Book>? Books { get; set; }
    }
}
