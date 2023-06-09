﻿using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Register")]
    public class RegisterController : Controller
    {
        readonly ApiHelper _apiHelper;
        public RegisterController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        [HttpGet("Index"), MyAuthorizationFilter(0, true, true)]
        public ActionResult Index()
        {
            ViewData["HideFooter"] = true;
            return View();
        }
        [HttpPost("Index"), MyAuthorizationFilter(0, true, true)]
        public async Task<ActionResult> Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            //Check



            //Register success!
            user.IsLocked = false;
            await _apiHelper.Post(user, "Users");
            MyMessage.Add("Success", "Register success!");
            return RedirectToAction("Index", "Login");
        }
    }
}
