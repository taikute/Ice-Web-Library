using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    public class AuthorsController : Controller
    {
        readonly ApiHelper _apiHelper;
        public AuthorsController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await _apiHelper.GetList<AuthorModel>("Authors")!;
            return View(authors);
        }
    }
}
