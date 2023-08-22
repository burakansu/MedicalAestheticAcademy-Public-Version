using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Data.Context;

namespace VeronaAkademi.Ui.Controllers
{
    public class PackageUiController : Controller
    {
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
            var model = Db.Package.Where(x => !x.Silindi).ToList();

            var data = model.ToList();
            return View(data);
        }

        public IActionResult Detail(int id)
        {
            var model = Db.Package
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                    .ThenInclude(x=>x.Course) 
                .Include(x => x.PackagePracticeLessonRelation)
                    .ThenInclude(x => x.PracticeLesson)
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Advisor)
                .Single(x => x.PackageId == id);

            return View(model);
        }

    }
}
