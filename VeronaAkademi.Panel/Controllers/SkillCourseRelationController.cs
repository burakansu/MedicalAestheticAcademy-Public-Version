using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class SkillCourseRelationController : BaseController<SkillCourseRelation>
    {
        public SkillCourseRelationController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Yetki("Kategoriler", "Skill", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var model = Db.SkillCourseRelation
                .Include(x => x.Skill)
                .Include(x => x.Course)
                .AsQueryable();

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Kategoriler", "Skill", "")]
        public IActionResult GetSkill(int id)
        {
            var model = Db.SkillCourseRelation
                .Include(x => x.Skill)
                .Include(x => x.Course)
                .Where(x => x.CourseId == id)
                .AsQueryable();

            var data = model.ToList();

            return PartialView(data);
        }

        [Yetki("Kategoriler", "Skill", "")]
        public IActionResult Form1(int CourseId)
        {
            SkillCourseRelation model = new SkillCourseRelation();
            model.CourseId = CourseId;

            return PartialView(model);
        }
    }
}
