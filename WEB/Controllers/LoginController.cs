using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Reflection;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {
        readonly RestClient client = new RestClient("https://localhost:7042/api/");
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
            var userExists = users.FirstOrDefault(u => u.Username == username);
            if (userExists == null) return BadRequest("User does not exists!");

            int id = userExists.UserId;
            int roleId = userExists.RoleId;
            var checkPassword = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            if (!checkPassword.IsSuccessful) return BadRequest("Fail!");

            bool isPassWordCorrect = bool.Parse(checkPassword.Content!);
            if (!isPassWordCorrect) return BadRequest($"Password does not correct!");

            //HttpContext.Session.SetString("username", username!);
            //HttpContext.Session.SetInt32("roleId", roleId);
            var changeOnline = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"))
            return RedirectToAction("Index", "Home");
        }
    }
}
