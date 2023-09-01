using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class LecturerCourseRelationController : BaseController<LecturerCourseRelation>
    {
        public LecturerCourseRelationController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Yetki("Kategoriler", "Lecturer", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var model = Db.LecturerCourseRelation
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .AsQueryable();

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Kategoriler", "Lecturer", "")]
        public IActionResult GetLecturer(int id)
        {
            var model = Db.LecturerCourseRelation
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .Where(x => x.CourseId == id)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kategoriler", "Lecturer", "")]
        public IActionResult Form1(int CourseId)
        {
            LecturerCourseRelation model = new LecturerCourseRelation();
            model.CourseId = CourseId;

            return PartialView(model);
        }
    }
}
