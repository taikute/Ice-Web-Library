using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly ApiHelper _apiHelper;

        public HomeController(ILogger<HomeController> logger, ApiHelper apiHelper)
        {
            _logger = logger;
            _apiHelper = apiHelper;
        }
        [Route("Privacy")]
        public ActionResult Privacy()
        {
            return View();
        }

        [HttpGet, MyAuthorizationFilter(1, false, true)]
        public async Task<ActionResult> Index()
        {
            var books = new List<Book>();
            var instances = await _apiHelper.GetAll<Instance>("Instances");
            var loans = await _apiHelper.GetAll<Loan>("Loans");

            foreach (var instance in instances!)
            {
                instance.Loans = loans!.Where(l => l.InstanceId == instance.Id).ToList();
                if (instance.Loans.Count > 0)
                {
                    var book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
                    if (book != null)
                    {
                        bool isExists = false;
                        foreach (var item in books)
                        {
                            if (item.Id == book.Id)
                            {
                                isExists = true;
                            }
                        }
                        if (!isExists)
                        {
                            books.Add(book);
                        }
                    }
                }
            }

            ViewData["MsgDict"] = MyMessage.Get();
            return View(books);
        }
        [HttpPost, Route("Search"), MyAuthorizationFilter(1, false, true)]
        public async Task<ActionResult> Search(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            var books = await _apiHelper.GetAll<Book>("Books");

            if (books == null)
            {
                return View();
            }

            searchTerm = searchTerm.ToLower();

            var titles = books.Where(b => b.Title.ToLower().Contains(searchTerm));

            foreach (var book in books)
            {
                book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
                book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
                book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            }

            var authors = books.Where(b => b.Author?.Name?.ToLower().Contains(searchTerm) == true);
            var categories = books.Where(b => b.Category?.Name?.ToLower().Contains(searchTerm) == true);
            var publisher = books.Where(b => b.Publisher?.Name?.ToLower().Contains(searchTerm) == true);

            Dictionary<string, IEnumerable<Book>?>? bookResult = new()
            {
                { "Title", titles.Take(50) },
                { "Author", authors.Take(50) },
                { "Category", categories.Take(50) },
                { "Publisher", publisher.Take(50) }
            };

            return View(bookResult);
        }
    }
}