using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Loans")]
    public class LoansController : Controller
    {
        readonly ApiHelper _apiHelper;
        public LoansController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [HttpGet, Route("Index/{userId?}"), MyAuthorizationFilter(2)]
        public async Task<IActionResult> Index(int? userId)
        {
            ViewData["MsgDict"] = MyMessage.Get();
            var loans = await _apiHelper.GetAll<Loan>("Loans");
            if (userId != null)
            {
                loans = loans!.Where(l => l.UserId == userId);
            }
            return View(loans);
        }

        [HttpGet("{id}"), Route("Get"), MyAuthorizationFilter(1, false, false)]
        public async Task<IActionResult> GetLoan(int id)
        {
            return View(await _apiHelper.GetByID<Loan>(id, "Loans"));
        }

        [HttpGet("{id}"), Route("Create"), MyAuthorizationFilter(1, false, false)]
        public async Task<IActionResult> Create(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books");
            return View(book);
        }
        [HttpPost("{id}"), Route("CreateConfirmed"), MyAuthorizationFilter(1, false, false)]
        public async Task<IActionResult> CreateConfirmed(int id)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var instances = await _apiHelper.GetAll<Instance>("Instances");
            var instance = instances!.Where(i => i.BookId == id && i.StatusId == 1).FirstOrDefault();
            if (instance == null) return BadRequest($"Out of book id={id}!");

            //Create Loan
            var loan = new Loan()
            {
                Id = 0,
                InstanceId = instance.Id,
                UserId = userId
            };
            await _apiHelper.Post(loan, "Loans");

            //Update Status
            instance.StatusId = 2;
            await _apiHelper.Put(instance, "Instances");

            //Update Quantity
            var book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
            book!.Quantity = instances!.Where(i => i.StatusId == 1 && i.BookId == book.Id).Count();
            await _apiHelper.Put(book, "Books");

            MyMessage.Add("Success", "Loan Success!");
            return RedirectToAction("Index", "Home");
        }
    }
}
