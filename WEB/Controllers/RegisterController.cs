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
        [ActionName("Index"), MyAuthorization(0, true, true)]
        public IActionResult Index()
        {
            ViewData["HideFooter"] = true;
            return View();
        }
        [HttpPost("Index"), MyAuthorization(0, true, true)]
        public async Task<IActionResult> Index(User user)
        {
            user.IsActived = true;
            user.IsOnline = false;
            if (ModelState.IsValid)
            {
                await _apiHelper.Post(user, "Users");
                MyMessage.Add("Success", "Register success!");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
