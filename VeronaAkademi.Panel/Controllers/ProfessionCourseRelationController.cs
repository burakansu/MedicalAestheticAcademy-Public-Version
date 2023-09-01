using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class ProfessionCourseRelationController : BaseController<ProfessionCourseRelation>
    {
        public ProfessionCourseRelationController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Yetki("Kategoriler", "Profession", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var model = Db.ProfessionCourseRelation
                .Include(x => x.Profession)
                .Include(x => x.Course)
                .AsQueryable();

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Kategoriler", "Profession", "")]
        public IActionResult Form1(int CourseId)
        {
            ProfessionCourseRelation model = new ProfessionCourseRelation();
            model.CourseId = CourseId;

            return PartialView(model);
        }

        [Yetki("Kategoriler", "Profession", "")]
        public IActionResult GetProfession(int id)
        {
            var model = Db.ProfessionCourseRelation
                .Include(x => x.Profession)
                .Include(x => x.Course)
                .Where(x=>x.CourseId == id)
                .AsQueryable();

            return PartialView(model.ToList());
        }
    }
}
