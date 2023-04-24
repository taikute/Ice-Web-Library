using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Authors")]
    public class AuthorsController : Controller
    {
        readonly ApiHelper _apiHelper;
        public AuthorsController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [HttpGet, Route("Index")]
        public async Task<IActionResult> Index()
        {
            var authors = await _apiHelper.GetAll<Author>("Authors")!;
            return View(authors);
        }
    }
}
