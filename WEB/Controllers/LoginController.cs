using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        [ActionName("Index"), MyAuthorization(0, true, true)]
        public IActionResult Index()
        {
            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;
            return View();
        }
        [HttpPost("Index"), MyAuthorization(0, true, true)]
        public async Task<ActionResult> Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var username = user.Username;
            var password = user.Password;
            var users = await _apiHelper.GetAll<User>("Users")!;
            var userExists = users!.FirstOrDefault(u => u.Username == username);
            if (userExists == null)
            {
                ModelState.AddModelError("Username", "Username does not exists!");
                return View(user);
            }

            int id = userExists.Id;
            int roleId = userExists.RoleId;
            var checkPassword = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            if (!checkPassword.IsSuccessful) return BadRequest("Fail!");
            bool isPassWordCorrect = bool.Parse(checkPassword.Content!);
            if (!isPassWordCorrect)
            {
                ModelState.AddModelError("Password", "Password does not correct!");
                return View(user);
            }

            var changeOnline = client.Execute(new RestRequest($"Users/CheckPassword?id={id}&password={password}"));
            HttpContext.Session.SetString("IsLogin", "true");
            HttpContext.Session.SetInt32("UserId", id);

            //HttpContext.Session.SetString("Username", username!);
            //HttpContext.Session.SetString("Name", userExists.Name!);
            //HttpContext.Session.SetInt32("RoleId", roleId);

            MyMessage.Add("Success", "Login success!");
            switch (roleId)
            {
                case 1:
                    {
                        return RedirectToAction("Index", "Home");
                    }
                case 2:
                    {
                        return RedirectToAction("Manager", "Books");
                    }
                case 3:
                    {
                        return RedirectToAction("Index", "Home");
                    }
                default:
                    {
                        return RedirectToAction("Index", "Home");
                    }
            }
        }

        [HttpGet, Route("Logout")]
        public IActionResult Logout()
        {
            MyMessage.Add("Success", "Logout successful!");
            HttpContext.Session.SetString("IsLogin", "false");
            return RedirectToAction("Index", "Home");
        }
    }
}
