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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            await _apiHelper.Post(user, "Users");
            return RedirectToAction("Index", "Login");
        }
    }
}
