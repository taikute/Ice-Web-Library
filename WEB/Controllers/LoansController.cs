//using Microsoft.AspNetCore.Mvc;
//using WEB.Helpers;
//using WEB.Models;

//namespace WEB.Controllers
//{
//    public class LoansController : Controller
//    {
//        readonly ApiHelper _apiHelper;
//        public LoansController(ApiHelper apiHelper)
//        {
//            _apiHelper = apiHelper;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpGet("{id}")]
//        [MyAuthorization(1)]
//        public async Task<IActionResult> GetLoan(int id)
//        {
//            return View(await _apiHelper.GetByID<Loan>(id, "Loans")!);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> Create(int id)
//        {
//            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
//            var instances = await _apiHelper.GetAll<Instance>("Instances")!;
//            var instance = instances.Where(i => i.BookId == id).FirstOrDefault();
//            if (instance == null) return BadRequest($"Out of book!{id}");

//            var loan = new Loan()
//            {
//                Id = 0,
//                InstanceId = instance.InstanceID,
//                UserId = userId
//            };
//            return View(loan);
//        }
//        [HttpPost]
//        public async Task<IActionResult> CreateConfirm(Loan loan)
//        {
//            await _apiHelper.Post(loan, "Loans");
//            return RedirectToAction("Index");
//        }
//    }
//}
