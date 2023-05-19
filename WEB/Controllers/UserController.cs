using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        readonly ApiHelper _apiHelper;
        public UserController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [Route("Index"), MyAuthorization(1)]
        public async Task<IActionResult> Index()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var loans = await _apiHelper.GetAll<Loan>("Loans");
            loans = loans!.Where(l => l.UserId == userId);
            return View(loans);
        }
    }
}
