using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewBag.SearchTerm = searchTerm;
            var books = await _apiHelper.GetList<BookSearchModel>("Books/GetListBookSearch")!;
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