using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
