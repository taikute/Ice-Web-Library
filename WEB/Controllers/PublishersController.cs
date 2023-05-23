using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Publishers")]
    public class PublishersController : Controller
    {
        readonly ApiHelper _apiHelper;
        public PublishersController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [MyAuthorizationFilter(1, false, true)]
        [Route("Index")]
        public async Task<ActionResult> Index()
        {
            return View(await _apiHelper.GetAll<Publisher>("Publishers"));
        }
    }
}
