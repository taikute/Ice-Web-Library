using WEB.Helpers;
using System.Collections.Generic;

namespace WEB.Models.Extend
{
    public class BookFilter
    {
        public IEnumerable<Book>? Books { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Publisher>? Publishers { get; set; }

        public BookFilter()
        {
            Authors = new ApiHelper().GetAll<Author>("Authors").Result;
            Categories = new ApiHelper().GetAll<Category>("Categories").Result;
            Publishers = new ApiHelper().GetAll<Publisher>("Publishers").Result;
        }
    }
}
