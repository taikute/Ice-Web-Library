using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Instances")]
    public class InstancesController : Controller
    {
        readonly ApiHelper _apiHelper;
        public InstancesController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet("Index")]
        public async Task<ActionResult> Index(int? bookId, int? id)
        {
            var instances = await _apiHelper.GetAll<Instance>("Instances");
            if (id != null)
            {
                instances = instances?.Where(i => i.Id == id);
            }
            if (bookId != null)
            {
                instances = instances?.Where(i => i.BookId == bookId);

            }
            if (instances != null)
                foreach (var instance in instances)
                {
                    instance.Status = await _apiHelper.GetByID<Status>(instance.StatusId, "Status");
                }

            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;
            return View(instances);
        }

        [HttpGet("BrokenConfirm")]
        public async Task<ActionResult> BrokenConfirm(int id)
        {
            var instance = await _apiHelper.GetByID<Instance>(id, "Instances");
            instance!.StatusId = 3;
            await _apiHelper.Put(instance, "Instances");
            MyMessage.Add("Success", "Update success!");
            return RedirectToAction("Index", "Instances", new { bookId = instance.BookId });
        }
    }
}
