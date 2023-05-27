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

        [Route("Index/{userId}"), MyAuthorizationFilter(1)]
        public async Task<IActionResult> Index(int id)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var loans = await _apiHelper.GetAll<Loan>("Loans");
            loans = loans!.Where(l => l.UserId == userId);
            return View(loans);
        }

        [MyAuthorizationFilter(2)]
        [HttpGet("ReaderManager")]
        public async Task<ActionResult> ReaderManager(int? userId)
        {
            var users = await _apiHelper.GetAll<User>("Users");

            if (userId.HasValue)
            {
                users = users?.Where(u => u.Id == userId);
            }

            users = users?.Where(u => u.RoleId == 1);

            if (users != null)
            {
                var loans = await _apiHelper.GetAll<Loan>("Loans");
                foreach (var user in users)
                {
                    user.Loans = loans?.Where(l => l.UserId == user.Id).ToList();
                }
            }
            return View(users);
        }
    }
}
