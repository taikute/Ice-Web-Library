using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        readonly ApiHelper _apiHelper;
        public UsersController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [Route("Index/{id}"), MyAuthorizationFilter(1)]
        public async Task<IActionResult> Index(int id)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var loans = await _apiHelper.GetAll<Loan>("Loans");
            loans = loans!.Where(l => l.UserId == userId);
            return View(loans);
        }

        public ActionResult Manager(int? id)
        {
            return View();
        }
    }
}
