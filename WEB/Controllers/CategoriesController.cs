using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Categories")]
    public class CategoriesController : Controller
    {
        readonly ApiHelper _apiHelper;
        public CategoriesController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [MyAuthorizationFilter(1, false, true)]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View(await _apiHelper.GetAll<Category>("Categories"));
        }
    }
}
