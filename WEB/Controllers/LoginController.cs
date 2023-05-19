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
        [HttpGet, Route("Index/{bugCode?}"), MyAuthorization(0)]
        public IActionResult Index(int? bugCode)
        {
            //1: Login Require
            //2: 

            ViewBag.LoginRequire = false;
            if (bugCode != null)
            {
                if (bugCode == 1)
                {
                    ViewBag.LoginRequire = true;
                }
            }
            return View();
        }
        [HttpPost, Route("Login"), MyAuthorization(0)]
        public async Task<IActionResult> Login(User user)
        {
            var username = user.Username;
            var password = user.Password;
            var users = await _apiHelper.GetAll<User>("Users")!;
            var userExists = users!.FirstOrDefault(u => u.Username == username);
            if (userExists == null) return BadRequest("User does not exists!");

            int id = userExists.Id;
            int roleId = userExists.RoleId;
            var checkPassword = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            if (!checkPassword.IsSuccessful) return BadRequest("Fail!");
            bool isPassWordCorrect = bool.Parse(checkPassword.Content!);
            if (!isPassWordCorrect) return BadRequest($"Password does not correct!");

            var changeOnline = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            HttpContext.Session.SetString("IsLogin", "true");
            HttpContext.Session.SetString("Username", username!);
            HttpContext.Session.SetString("Name", userExists.Name!);
            HttpContext.Session.SetInt32("UserId", userExists.Id);
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
