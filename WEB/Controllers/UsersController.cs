using Microsoft.AspNetCore.Mvc;
using WEB.Helpers;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        readonly ApiHelper _apiHelper;
        public UsersController(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        [Route("Profile"), MyAuthorizationFilter(1)]
        public async Task<ActionResult> Profile()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var user = await _apiHelper.GetByID<User>(userId, "Users");
            var loans = await _apiHelper.GetAll<Loan>("Loans");

            loans = loans?.Where(l => l.UserId == userId);
            if (loans != null)
            {
                loans = loans.OrderByDescending(loans => loans.BorrowedDate);
                foreach (var loan in loans)
                {
                    var instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                    instance!.Book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
                    loan.Instance = instance;
                }
                user!.Loans = loans.ToList();
            }

            int fine = 0;
            if (user!.Loans != null)
            {
                foreach (var loan in user.Loans)
                {
                    if (loan.StatusId == -2)
                    {
                        fine += loan.Instance!.Book!.Price;
                    }
                }
            }

            ViewData["Fine"] = fine;
            ViewData["MsgDict"] = MyMessage.Get();
            return View(user);
        }

        [MyAuthorizationFilter(1)]
        [HttpGet("EmailVerification")]
        public async Task<ActionResult> EmailVerification(int id)
        {
            var user = await _apiHelper.GetByID<User>(id, "Users");
            user!.LoanLeft++;
            await _apiHelper.Put(user, "Users");
            MyMessage.Add("Success", "Verification success, you recieve 1 loan!");
            return RedirectToAction("Profile", "Users");
        }

        [MyAuthorizationFilter(2)]
        [HttpGet("ReaderManager")]
        public async Task<ActionResult> ReaderManager(int? userId, bool? isLock)
        {
            var users = await _apiHelper.GetAll<User>("Users");

            users = users?.Where(u => u.RoleId == 1);
            //Relation Ship
            if (users != null)
            {
                var loans = await _apiHelper.GetAll<Loan>("Loans");
                foreach (var user in users)
                {
                    user.Loans = loans?.Where(l => l.UserId == user.Id && l.StatusId == -2).ToList();
                    if (user.Loans != null)
                        foreach (var loan in user.Loans)
                        {
                            loan.Instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                            if (loan.Instance != null)
                                loan.Instance.Book = await _apiHelper.GetByID<Book>(loan.Instance.BookId, "Books");
                        }
                }
            }

            if (userId.HasValue && isLock.HasValue)
            {
                var user = users!.First(u => u.Id == userId);
                if (!isLock.Value)
                {
                    foreach (var loan in user.Loans!)
                    {
                        loan.StatusId = 3;
                        loan.ReturnedDate = DateTime.Now;
                        await _apiHelper.Put(loan, "Loans");
                    }
                }

                user!.IsLocked = isLock.Value;
                await _apiHelper.Put(user, "Users");
                //users = users?.Where(u => u.Id == userId);
            }

            return View(users);
        }

        [MyAuthorizationFilter(3)]
        [HttpGet("LibrarianManager")]
        public async Task<ActionResult> LibrarianManager()
        {
            var users = await _apiHelper.GetAll<User>("Users");
            users = users!.Where(u => u.RoleId == 2);

            ViewData["MsgDict"] = MyMessage.Get();
            ViewData["HideFooter"] = true;
            return View(users);
        }


        [MyAuthorizationFilter(3)]
        [HttpGet("CreateLib")]
        public ActionResult CreateLib()
        {
            ViewData["HideFooter"] = true;
            return View();
        }

        [MyAuthorizationFilter(3)]
        [HttpPost("CreateLib")]
        public async Task<ActionResult> CreateLib(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }


            user.RoleId = 2;
            await _apiHelper.Post(user, "Users");
            return RedirectToAction("LibrarianManager");
        }
    }
}
