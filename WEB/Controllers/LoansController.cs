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

        [HttpGet, Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.LoanIsNull = false;
            var loans = await _apiHelper.GetAll<Loan>("Loans");
            if (loans == null) ViewBag.LoanIsNull = true;
            return View(loans);
        }

        [HttpGet("{id}"), Route("Get"), MyAuthorization(1)]
        public async Task<IActionResult> GetLoan(int id)
        {
            return View(await _apiHelper.GetByID<Loan>(id, "Loans"));
        }

        [HttpGet("{id}"), Route("Create"), MyAuthorization(1)]
        public async Task<IActionResult> Create(int id)
        {
            var book = await _apiHelper.GetByID<Book>(id, "Books");
            return View(book);
        }
        [HttpPost("{id}"), Route("CreateConfirmed"), MyAuthorization(1)]
        public async Task<IActionResult> CreateConfirmed(int id)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var instances = await _apiHelper.GetAll<Instance>("Instances");
            var instance = instances!.Where(i => i.BookId == id && i.StatusId == 1).FirstOrDefault();
            if (instance == null) return BadRequest($"Out of book id={id}!");
            var loan = new Loan()
            {
                Id = 0,
                InstanceId = instance.Id,
                UserId = userId
            };
            await _apiHelper.Post(loan, "Loans");
            instance.StatusId = 2;
            await _apiHelper.Put(instance, "Instances");
            return RedirectToAction("Index", "Home", new { status = 3 });
        }
    }
}
