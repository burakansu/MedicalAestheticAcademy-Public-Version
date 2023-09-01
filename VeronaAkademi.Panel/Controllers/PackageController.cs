using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.EntityFramework;

namespace VeronaAkademi.Panel.Controllers
{
    public class PackageController : BaseController<Package>
    {
        public PackageController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
            repo = new PackageRepository();
        }

        [Menu("Paketler", "fa-solid fa-box", "Paket", 0, 13)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Paketler", "Package", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetPackage(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetCourse(int id)
        {
            var model = Db.PackageCourseRelation
                .Include(x => x.Course.PackageCourseRelation)
                    .ThenInclude(x => x.Package)
                .Where(x => x.PackageId == id)
                .Select(x => x.Course)
                .Where(x => !x.Deleted)
                .ToList();

            return PartialView(model);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetAdvisor(int id)
        {
            var model = Db.PackageAdvisorRelation
                .Include(x => x.Advisor.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Advisor.Currency)
                .Where(x => x.PackageId == id && !x.Advisor.Deleted)
                .Select(x => x.Advisor)
                .ToList();

            return PartialView(model);
        }
        [Yetki("Paketler", "Package", "")]
        public IActionResult GetPracticeLesson(int id)
        {
            var model = Db.PackagePracticeLessonRelation
                .Where(x => x.PackageId == id)
                .Select(x => x.PracticeLesson)
                .Where(x => !x.Deleted)
                .ToList();

            return PartialView(model);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult Detail(int id)
        {
            return View(repo.Get(id));
        }

        [HttpPost]
        public void UpdateStartdate(PackageCourseRelation packageCourseRelation)
        {
            Db.PackageCourseRelation.Update(packageCourseRelation);
            Db.SaveChanges();
        }

        public void Update(Package form)
        {
            form.Active = true;
            Db.Package.Update(form);
            Db.SaveChanges();
        }
    }
}
