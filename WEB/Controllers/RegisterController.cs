using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Register")]
    public class RegisterController : Controller
    {
        readonly ApiHelper _apiHelper;
        public RegisterController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, Route("Index")]
        public async Task<IActionResult> Register(User user)
        {
            user.IsActived = true;
            user.IsOnline = false;
            if (ModelState.IsValid)
            {
                await _apiHelper.Post(user, "Users");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Register", new { user });
            }
        }
    }
}
