using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Controllers
{
    public class AdvisorUiController : Controller
    {
        CookieHelper cookieHelper = new CookieHelper();
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
            return View();
        }

        public IActionResult Detail(int id)
        {
            var model = Db.Advisor
                .Include(x => x.Lecturer)
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Package)
                .Include(x => x.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Currency)
                .Single(x => x.AdvisorId == id);

            return View(model);
        }

        public IActionResult MyAdvisors()
        {
            int customerid = Int32.Parse(cookieHelper.Get("CustomerId"));

            var model = Db.Advisor
                .Include(x => x.CustomerAdvisorRelation)
                    .ThenInclude(x => x.Customer)
                .SelectMany(x => x.CustomerAdvisorRelation)
                .Where(x => x.CustomerId == customerid)
                .Select(x => x.Advisor) 
                .ToList();

            return View(model);
        }

        public IActionResult MyAdvisorChat(int AdvisorId)
        {
            int customerid = Int32.Parse(cookieHelper.Get("CustomerId"));

            var a = Db.Advisor
                .Include(x => x.CustomerAdvisorRelation)
                    .ThenInclude(x => x.Customer)
                .SelectMany(x => x.CustomerAdvisorRelation)
                .Single(x => x.CustomerId == customerid && x.AdvisorId == AdvisorId);

            var model = Db.Message
               .Include(x => x.Advisor)
               .Include(x => x.Customer)
               .Where(x => x.AdvisorId == a.AdvisorId && x.CustomerId == a.CustomerId)
               .OrderBy(x => x.EklemeTarihi)
               .ToList();

            ViewBag.AdvisorId = AdvisorId;
            return PartialView(model);
        }

        [HttpPost]
        public void SaveMessage(Message message)
        {
            int customerid = Int32.Parse(cookieHelper.Get("CustomerId"));
            message.CustomerId = customerid;
            message.EklemeTarihi = DateTime.Now;
            message.Type = 1;
            message.Aktif = true;

            Db.Message.Add(message);
            Db.SaveChanges();
        }
    }
}
