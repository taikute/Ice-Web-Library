using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        readonly RestClient client = new RestClient("https://localhost:7042/api/");
        readonly ApiHelper _apiHelper;
        public LoginController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            var username = user.Username;
            var password = user.Password;
            var users = await _apiHelper.GetAll<User>("Users")!;
            var userExists = users.FirstOrDefault(u => u.Username == username);
            if (userExists == null) return BadRequest("User does not exists!");

            int id = userExists.UserId;
            int roleId = userExists.RoleId;
            var checkPassword = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            if (!checkPassword.IsSuccessful) return BadRequest("Fail!");

            bool isPassWordCorrect = bool.Parse(checkPassword.Content!);
            if (!isPassWordCorrect) return BadRequest($"Password does not correct!");

            var changeOnline = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            HttpContext.Session.SetString("IsLogin", "true");
            HttpContext.Session.SetString("Username", username!);
            HttpContext.Session.SetInt32("UserId", userExists.UserId);
            HttpContext.Session.SetInt32("RoleId", userExists.RoleId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet, Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("IsLogin", "false");
            return RedirectToAction("Index", "Home");
        }
    }
}
