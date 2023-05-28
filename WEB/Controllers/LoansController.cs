using Microsoft.AspNetCore.Mvc;
using System.Timers;
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

        [HttpGet, Route("Index"), MyAuthorizationFilter(2, false, false)]
        public async Task<ActionResult> Index(int? userId, int? instanceId, int statusId = 0)
        {
            ViewData["MsgDict"] = MyMessage.Get();

            var loans = await _apiHelper.GetAll<Loan>("Loans");
            if (instanceId != null)
            {
                loans = loans?.Where(l => l.InstanceId == instanceId);
            }
            if (userId != null)
            {
                loans = loans?.Where(l => l.UserId == userId);
            }
            if (statusId != 0)
            {
                loans = loans?.Where(l => l.StatusId == statusId);
            }
            if (loans != null)
            {
                foreach (var loan in loans)
                {
                    var instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                    loan.Instance = instance;
                    var book = await _apiHelper.GetByID<Book>(instance!.BookId, "Books");
                    loan.Instance!.Book = book;
                    var user = await _apiHelper.GetByID<User>(loan.UserId, "Users");
                    loan.User = user;
                }
                loans = loans.OrderByDescending(l => l.BorrowedDate);
            }

            ViewData["SearchTerm"] = instanceId;
            ViewData["StatusId"] = statusId;
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
        public async Task<ActionResult> CreateConfirmed(int id)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var instances = await _apiHelper.GetAll<Instance>("Instances");
            var instance = instances!.Where(i => i.BookId == id && i.StatusId == 1).FirstOrDefault();
            if (instance == null)
            {
                MyMessage.Add("Warning", "Out of book!");
                return RedirectToAction("Detail", "Books", new { id });
            }

            var user = await _apiHelper.GetByID<User>(userId, "Users");
            if (user!.LoanLeft == 0)
            {
                MyMessage.Add("Warning", "Out of loans!");
                return RedirectToAction("Detail", "Books", new { id });
            }

            //Create Loan
            var loan = new Loan()
            {
                Id = 0,
                InstanceId = instance.Id,
                UserId = userId
            };
            await _apiHelper.Post(loan, "Loans");

            //Update LoanLeft
            user!.LoanLeft--;
            await _apiHelper.Put(user, "Users");

            //Update Status
            instance.StatusId = 2;
            await _apiHelper.Put(instance, "Instances");

            //Update Quantity
            var book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
            book!.Quantity = instances!.Where(i => i.StatusId == 1 && i.BookId == book.Id).Count();
            await _apiHelper.Put(book, "Books");

            //Set Due Pickup Date
            DateTime duePickupDate = loan.BorrowedDate.AddSeconds(20);
            System.Timers.Timer timer = new();
            timer.Elapsed += async (sender, e) =>
            {
                //không biết id
                var loans = await _apiHelper.GetAll<Loan>("Loans");
                var newLoan = loans!.First(l=>l.InstanceId == instance.Id);
                if (newLoan?.StatusId == 1)
                {
                    MyMessage.Add("Danger", "Due pickup date!");
                }
            };
            timer.Interval = (duePickupDate - DateTime.Now).TotalMilliseconds;
            timer.AutoReset = false;

            timer.Start();

            MyMessage.Add("Success", "Loan Success!");
            return RedirectToAction("Profile", "Users");
        }
        private void LoanExpirationHandler(object sender, ElapsedEventArgs e)
        {
            MyMessage.Add("Success", "10s pass");
        }

        [HttpGet("UpdateStatus")]
        public async Task<ActionResult> UpdateStatus(string? citizenId, string? phoneNumber, int loanId, bool isCancel = false)
        {
            var loan = await _apiHelper.GetByID<Loan>(loanId, "Loans");
            if (loan!.StatusId == 3)
            {
                MyMessage.Add("Danger", "Cant update status!");
            }
            else if (isCancel)
            {
                //Update instance status and quantity
                loan!.StatusId = -3;
                var instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                instance!.StatusId = 1;
                await _apiHelper.Put(instance, "Instances");
                var book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
                book!.Quantity++;
                await _apiHelper.Put(book, "Books");
                var user = await _apiHelper.GetByID<User>(loan.UserId, "Users");
                user!.LoanLeft++;
                await _apiHelper.Put(user, "Users");

                MyMessage.Add("Success", "Cancel loan success!");
            }
            else
            {
                loan!.StatusId++;
                if (loan.StatusId == 2)
                {
                    string digit = "0123456789";
                    if (citizenId?.Length != 12)
                    {
                        MyMessage.Add("Danger", "Citizen ID must be exactly 12 characters long!");
                        return RedirectToAction("Index", "Loans");
                    }
                    else
                    {
                        for (int i = 0; i < citizenId.Length; i++)
                        {
                            if (!digit.Contains(citizenId[i]))
                            {
                                MyMessage.Add("Danger", "Citizen ID must contain only digits!");
                                return RedirectToAction("Index", "Loans");
                            }
                        }
                    }
                    if (phoneNumber?.Length != 10)
                    {
                        MyMessage.Add("Danger", "Phone Number must be exactly 10 characters long!");
                        return RedirectToAction("Index", "Loans");
                    }
                    else
                    {
                        for (int i = 0; i < phoneNumber.Length; i++)
                        {
                            if (!digit.Contains(phoneNumber[i]))
                            {
                                MyMessage.Add("Danger", "Phone Number must contain only digits!");
                                return RedirectToAction("Index", "Loans");
                            }
                        }
                    }
                    var user = await _apiHelper.GetByID<User>(loan.UserId, "Users");
                    user!.CitizenIdentificationNumber = citizenId;
                    user.PhoneNumber = phoneNumber;
                    user.LoanLeft++;
                    await _apiHelper.Put(user, "Users");
                }

                if (loan.StatusId == 3)
                {
                    //Update instance status and quantity
                    var instance = await _apiHelper.GetByID<Instance>(loan.InstanceId, "Instances");
                    instance!.StatusId = 1;
                    await _apiHelper.Put(instance, "Instances");
                    var book = await _apiHelper.GetByID<Book>(instance.BookId, "Books");
                    book!.Quantity++;
                    await _apiHelper.Put(book, "Books");

                    //Update Returned Date
                    loan!.ReturnedDate = DateTime.Now;
                }
                MyMessage.Add("Success", "Update status success!");
            }

            await _apiHelper.Put(loan, "Loans");
            return RedirectToAction("Index", "Loans");
        }
    }
}
