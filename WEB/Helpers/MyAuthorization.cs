using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WEB.Models;

namespace WEB.Helpers
{
    public class MyAuthorization : ActionFilterAttribute
    {
        //Role 0: if IsLogin, cant go to this page
        readonly int[] _roleId;
        public MyAuthorization(params int[] roleId)
        {
            _roleId = roleId;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = filterContext.HttpContext;
            bool isLogin = bool.Parse(context.Session.GetString("IsLogin") ?? "false");
            if (_roleId.Contains(0))
            {
                if (isLogin)
                {
                    filterContext.Result = new RedirectResult("/4");
                    return;
                }
                else
                {
                    return;
                }
            }

            if (!isLogin)
            {
                filterContext.Result = new RedirectResult("/Login/Index/1");
                return;
            }
            int? roleId = context.Session.GetInt32("RoleId");
            if (roleId == null)
            {
                filterContext.Result = new RedirectResult("/1");
                return;
            }
            bool isRoleExists = false;
            for (int i = 0; i < _roleId.Length; i++)
            {
                if (roleId == _roleId[i])
                {
                    isRoleExists = true;
                    break;
                }
            }
            if (!isRoleExists)
            {
                filterContext.Result = new RedirectResult("/1");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
