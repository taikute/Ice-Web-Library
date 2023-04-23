﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEB.Helpers
{
    public class MyAuthorization : ActionFilterAttribute
    {
        readonly int[] _roleId;
        public MyAuthorization(params int[] roleId)
        {
            _roleId = roleId;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = filterContext.HttpContext;
            bool isLogin = bool.Parse(context.Session.GetString("IsLogin") ?? "false");
            if (!isLogin)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            int? roleId = context.Session.GetInt32("RoleId");
            if (roleId == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
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
                filterContext.Result = new RedirectResult("/Home/Index");
                return;
            }
            // Thực hiện các xử lý khác nếu cần
            base.OnActionExecuting(filterContext);
        }
    }
}
