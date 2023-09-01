using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace WebApplication2.Controllers
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
                {
                    _db = new Db();
                }
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
            var id = Int32.Parse(cookieHelper.Get("CustomerId"));
            var model = Db.Advisor
                .Include(x => x.CustomerAdvisorRelation)
                    .ThenInclude(x => x.Customer)
                .SelectMany(x => x.CustomerAdvisorRelation)
                .Where(x => x.CustomerId == id)
                .Select(x => x.Advisor)
                .ToList();

            foreach (var item in model)
            {
                if (Db.Anamnez.Count(x=>x.CustomerId == id && x.AdvisorId == item.AdvisorId) == 0)
                    Db.Anamnez.Add(new Anamnez { AdvisorId = item.AdvisorId, CustomerId = id });

                if (Db.ClinicalExam.Count(x => x.CustomerId == id && x.AdvisorId == item.AdvisorId) == 0)
                    Db.ClinicalExam.Add(new ClinicalExam { AdvisorId = item.AdvisorId, CustomerId = id });

                Db.SaveChanges();
            }

            return View(model);
        }

        public IActionResult DetailForm(int AdvisorId)
        {
            var id = Int32.Parse(cookieHelper.Get("CustomerId"));
            ViewBag.Anamnez = Db.Anamnez.Single(x => x.CustomerId == id && x.AdvisorId == AdvisorId);
            ViewBag.ClinicalExam = Db.ClinicalExam.Single(x => x.CustomerId == id && x.AdvisorId == AdvisorId);
            ViewBag.advisorId = AdvisorId;

            return PartialView();
        }

        public IActionResult MyAdvisorChat(int AdvisorId)
        {
            var a = Db.Advisor
                .Include(x => x.CustomerAdvisorRelation)
                    .ThenInclude(x => x.Customer)
                .SelectMany(x => x.CustomerAdvisorRelation)
                .Single(x => x.CustomerId == Int32.Parse(cookieHelper.Get("CustomerId")) && x.AdvisorId == AdvisorId);

            var model = Db.Message
               .Include(x => x.Advisor)
               .Include(x => x.Customer)
               .Where(x => x.AdvisorId == a.AdvisorId && x.CustomerId == a.CustomerId)
               .OrderBy(x => x.CreateDate)
               .ToList();

            ViewBag.AdvisorId = AdvisorId;
            return PartialView(model);
        }

        [HttpPost]
        public void SaveMessage(Message message)
        {
            message.CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));
            message.CreateDate = DateTime.Now;
            message.Type = 1;
            message.Active = true;

            Db.Message.Add(message);
            Db.SaveChanges();
        }
    }
}
