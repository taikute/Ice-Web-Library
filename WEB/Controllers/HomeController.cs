using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics;
using WEB.Helpers;
using WEB.Models;
using static System.Reflection.Metadata.BlobBuilder;

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
        [HttpGet("{status?}")]
        public IActionResult Index(int? status)
        {
            ViewBag.RoleInvalid = false;
            ViewBag.LogoutSuccess = false;
            ViewBag.LoanSuccess = false;
            if (status != null)
            {
                if (status == 1) ViewBag.RoleInvalid = true;
                if (status == 2) ViewBag.LogoutSuccess = true;
                if (status == 3) ViewBag.LoanSuccess = true;
            }
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
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