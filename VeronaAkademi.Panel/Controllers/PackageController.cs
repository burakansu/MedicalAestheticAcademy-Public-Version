using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class PackageController : BaseController<Package>
    {
        public PackageController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
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
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = Db.Package
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Course")
                .Include(x => x.PackagePracticeLessonRelation)
                .Include("PackagePracticeLessonRelation.PracticeLesson")
                .Include(x => x.PackageAdvisorRelation)
                .Include("PackageAdvisorRelation.Advisor")
                .Where(x => !x.Silindi)
                .AsQueryable();


            var data = model.ToList();

            return PartialView(data);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetPackage(int id)
        {
            var model = Db.Package
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Course")
                .Include(x => x.PackagePracticeLessonRelation)
                .Include("PackagePracticeLessonRelation.PracticeLesson")
                .Include(x => x.PackageAdvisorRelation)
                .Include("PackageAdvisorRelation.Advisor")
                .Single(x => x.PackageId == id);

            return PartialView(model);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetCourse(int id)
        {
            var model = Db.PackageCourseRelation
                .Include(x => x.Course.PackageCourseRelation)
                    .ThenInclude(x => x.Package)
                .Where(x => x.PackageId == id)
                .Select(x => x.Course)
                .Where(x => !x.Silindi)
                .ToList()
                .AsQueryable();

            var data = model.ToList();

            return PartialView(data);
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult GetAdvisor(int id)
        {
            var model = Db.PackageAdvisorRelation
    .Include(x => x.Advisor.AdvisorCourseRelation)
        .ThenInclude(x => x.Course)
    .Include(x => x.Advisor.Currency)
    .Where(x => x.PackageId == id && !x.Advisor.Silindi)
    .Select(x => x.Advisor)
    .ToList()
    .AsQueryable();



            return PartialView(model.ToList());
        }
        [Yetki("Paketler", "Package", "")]
        public IActionResult GetPracticeLesson(int id)
        {
            var model = Db.PackagePracticeLessonRelation
                .Where(x => x.PackageId == id)
                .Select(x => x.PracticeLesson)
                .Where(x => !x.Silindi)
                .ToList()
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Paketler", "Package", "")]
        public IActionResult Detail(int id)
        {
            Package model = Db.Package
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Course")
                .Include(x => x.PackagePracticeLessonRelation)
                .Include("PackagePracticeLessonRelation.PracticeLesson")
                .AsQueryable()
                .Single(x => x.PackageId == id);


            return View(model);
        }

        [HttpPost]
        public void UpdateStartdate(PackageCourseRelation packageCourseRelation)
        {
            Db.PackageCourseRelation.Update(packageCourseRelation);
            Db.SaveChanges();
        }

        public override JsonResult Save(Package form)
        {
            return base.Save(form);
        }

        public void Update(Package form)
        {
            form.Aktif = true;
            Db.Package.Update(form);
            Db.SaveChanges();
        }
    }
}
