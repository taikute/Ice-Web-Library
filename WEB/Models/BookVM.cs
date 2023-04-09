using System.ComponentModel.DataAnnotations;
using WEB.Helpers;

namespace WEB.Models
{
    public class BookVM
    {
        public int ID { get; set; }
        public int Code { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
