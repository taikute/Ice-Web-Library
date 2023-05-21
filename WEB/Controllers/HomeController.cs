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
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet, MyAuthorization(1, false, true)]
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("IsApiResponse", "true");
            if (!await _apiHelper.IsResponse())
            {
                HttpContext.Session.SetString("IsApiResponse", "false");
                return RedirectToAction("MyNotFound", "Errors");
            }

            ViewData["MsgDict"] = MyMessage.Get();
            return View();
        }
        [HttpPost, Route("Search"), MyAuthorization(1, false, true)]
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            var books = await _apiHelper.GetAll<Book>("Books")!;
            foreach (var book in books!)
            {
                book.Author = await _apiHelper.GetByID<Author>(book.AuthorId, "Authors")!;
                book.Category = await _apiHelper.GetByID<Category>(book.CategoryId, "Categories")!;
                book.Publisher = await _apiHelper.GetByID<Publisher>(book.PublisherId, "Publishers")!;
            }
            var lowerSearchTerm = searchTerm.ToLower();
            var result = books.Where(b =>
                b.Title!.ToLower().Contains(lowerSearchTerm)
                || b.Author!.Name!.ToLower().Contains(lowerSearchTerm)
                || b.Publisher!.Name!.ToLower().Contains(lowerSearchTerm)
                || b.Category!.Name!.ToLower().Contains(lowerSearchTerm))
                .ToList();
            return View(result);
        }
    }
}