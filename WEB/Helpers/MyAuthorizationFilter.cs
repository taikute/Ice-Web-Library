using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;
using WEB.Models;

namespace WEB.Helpers
{
    public class MyAuthorizationFilter : ActionFilterAttribute
    {
        readonly int _roleId;
        readonly bool _noAccessWhileLogin;
        readonly bool _guestAccept;
        readonly ApiHelper _apiHelper;
        public MyAuthorizationFilter(int roleId, bool noAccessWhileLogin = false, bool guestAccept = false)
        {
            _roleId = roleId;
            _noAccessWhileLogin = noAccessWhileLogin;
            _guestAccept = guestAccept;
            _apiHelper = new ApiHelper();
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HttpContext HttpContext = context.HttpContext;
            HttpContext.Session.SetString("IsApiResponse", _apiHelper.IsResponse().Result.ToString());

            if (!bool.Parse(HttpContext.Session.GetString("IsApiResponse") ?? "false"))
            {
                MyMessage.Add("Danger", "Can't connect to database!");
                context.Result = new RedirectToActionResult("MyNotFound", "Errors", null);
            }
            else if (!bool.Parse(HttpContext.Session.GetString("IsLogin") ?? "false"))
            {
                if (!_guestAccept)
                {
                    MyMessage.Add("Danger", "Login require!");
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                }
            }
            else if (_noAccessWhileLogin)
            {
                MyMessage.Add("Danger", "Already login!");
                context.Result = new RedirectToActionResult("MyAccessDenied", "Errors", null);
            }
            else if (_roleId != _apiHelper.GetByID<User>(HttpContext.Session.GetInt32("UserId") ?? 3, "Users").Result!.RoleId)
            {
                MyMessage.Add("Danger", "Role invalid!");
                context.Result = new RedirectToActionResult("MyNotFound", "Errors", null);
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
