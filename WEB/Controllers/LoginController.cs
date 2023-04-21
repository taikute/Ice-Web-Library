using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {
        readonly ApiHelper _apiHelper;
        public LoginController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var username = user.Username;
            var password = user.Password;
            var users = await _apiHelper.GetAll<User>("Users")!;
            bool isUserExists = users.Any(u => u.Username == username && u.Password == password);
            if (!isUserExists)
            {
                return BadRequest("User Does not exists!");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
