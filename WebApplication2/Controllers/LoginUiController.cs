using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Controllers
{
    public class LoginUiController : Controller
    {
        private readonly CookieHelper cookieHelper;
        private readonly IConfiguration _config;

        public string UserNameTag { get; set; }
        public string PasswordTag { get; set; }
        public string CustomerIdTag { get; set; }


        public LoginUiController(IConfiguration config)
        {
            cookieHelper = new CookieHelper();
            _config = config;

            CustomerIdTag = _config.GetValue<string>("CookieSettings:CustomerIdTag");

        }

        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null)
                    _db = new Db();

                return _db;
            }
        }
        public IActionResult Index()
        {
            CustomerIdTag = "CustomerId";
            if (cookieHelper.Get(CustomerIdTag) != "")
                cookieHelper.Delete(CustomerIdTag);

            return View();
        }
        public IActionResult Entering(Customer customer)
        {
            if (Db.Customer
                .Where(x => x.Email == customer.Email && x.Password == customer.Password)
                .Count() > 0)
            {
                CustomerIdTag = "CustomerId";
                cookieHelper.Set(CustomerIdTag, Db.Customer.First(x => x.Email == customer.Email && x.Password == customer.Password).CustomerId.ToString(), DateTime.Now.AddYears(1));

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            cookieHelper.Delete(CustomerIdTag);
            return RedirectToAction("Index", "Home");
        }
    }
}
