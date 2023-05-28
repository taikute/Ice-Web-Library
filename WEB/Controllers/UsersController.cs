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

        [Route("Profile"), MyAuthorizationFilter(1)]
        public async Task<IActionResult> Profile()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var user = await _apiHelper.GetByID<User>(userId, "Users");
            var loans = await _apiHelper.GetAll<Loan>("Loans");

            loans = loans?.Where(l => l.UserId == userId);
            if (loans != null)
            {
                foreach (var loan in loans)
                {
                    var instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                    instance!.Book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
                    loan.Instance = instance;
                }
                user!.Loans = loans.ToList();
            }
            ViewData["MsgDict"] = MyMessage.Get();
            return View(user);
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
