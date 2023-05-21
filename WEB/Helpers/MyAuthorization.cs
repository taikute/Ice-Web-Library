using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;
using WEB.Models;

namespace WEB.Helpers
{
    public class MyAuthorization : ActionFilterAttribute
    {
        readonly int _roleId;
        readonly bool _noAccessWhileLogin;
        readonly bool _guestAccept;
        readonly ApiHelper _apiHelper;
        public MyAuthorization(int roleId, bool noAccessWhileLogin = false, bool guestAccept = false)
        {
            _roleId = roleId;
            _noAccessWhileLogin = noAccessWhileLogin;
            _guestAccept = guestAccept;
            _apiHelper = new ApiHelper();
        }
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            HttpContext HttpContext = context.HttpContext;
            bool IsLogin = bool.Parse(HttpContext.Session.GetString("IsLogin") ?? "false");
            int userId = HttpContext.Session.GetInt32("UserId") ?? 3;
            User? user = await _apiHelper.GetByID<User>(userId, "Users");

            if (!IsLogin)
            {
                if (!_guestAccept)
                {
                    MyMessage.Add("Danger", "Login require!");
                    context.Result = new RedirectResult("/Login/Index");
                }
            }
            else if (_noAccessWhileLogin)
            {
                MyMessage.Add("Danger", "Already login!");
                context.Result = new RedirectToActionResult("MyAccessDenied", "Errors", null);
            }
            else if (_roleId != user!.RoleId)
            {
                MyMessage.Add("Danger", "Role invalid!");
                context.Result = new RedirectToActionResult("MyNotFound", "Errors", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
