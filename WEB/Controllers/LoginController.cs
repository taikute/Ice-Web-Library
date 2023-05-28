using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        readonly RestClient client = new RestClient("https://localhost:7042/api/");
        readonly ApiHelper _apiHelper;
        public LoginController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [MyAuthorizationFilter(0, true, true)]
        [HttpGet("Index")]
        public ActionResult Index()
        {
            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;

            return View();
        }

        [MyAuthorizationFilter(0, true, true)]
        [HttpPost("Index")]
        public async Task<ActionResult> Index(User user)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Email");
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var username = user.Username;
            var password = user.Password;
            var users = await _apiHelper.GetAll<User>("Users")!;
            var userExists = users!.FirstOrDefault(u => u.Username == username);

            if (userExists == null)
            {
                ModelState.AddModelError("Username", "Username does not exist.");
                return View(user);
            }

            //if (userExists.IsLocked)
            //{
            //    ModelState.AddModelError("Username", "Account has been locked.");
            //    return View(user);
            //}

            int id = userExists.Id;
            int roleId = userExists.RoleId;
            bool isPasswordCorrect = bool.Parse(client.Execute(new RestRequest($"Users/CheckPassword/{id}/{password}")).Content ?? "false");

            if (!isPasswordCorrect)
            {
                ModelState.AddModelError("Password", "Password is incorrect.");
                return View(user);
            }

            //Login Accept
            HttpContext.Session.SetString("IsLogin", "true");
            HttpContext.Session.SetInt32("UserId", id);

            MyMessage.Add("Success", "Login success");
            switch (roleId)
            {
                case 1:
                    {
                        return RedirectToAction("Index", "Home");
                    }
                case 2:
                    {
                        return RedirectToAction("Index", "Loans");
                    }
                case 3:
                    {
                        return RedirectToAction("LibrarianManager", "Users");
                    }
                default:
                    {
                        return RedirectToAction("Index", "Home");
                    }
            }
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            MyMessage.Add("Success", "Logout success!");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.SetString("IsLogin", "false");
            return RedirectToAction("Index", "Home");
        }
    }
}
