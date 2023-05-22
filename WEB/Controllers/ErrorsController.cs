using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;

namespace WEB.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult MyNotFound()
        {
            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;
            return View();
        }
        public ActionResult MyAccessDenied()
        {
            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;
            return View();
        }
    }
}
