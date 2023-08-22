using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class SkillCourseRelationController : BaseController<SkillCourseRelation>
    {
        public SkillCourseRelationController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

       // [Menu("Kurs-Beceri", "fa-sharp fa-solid fa-link", "İlişkilendirme", 5, 5)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kategoriler", "Skill", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = "";
            var model = Db.SkillCourseRelation
                .Include(x => x.Skill)
                .Include(x => x.Course)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(x => x.SkillCourseRelationId.ToString() == searchText);
            }

            var durum = Request.Query["Durum"].ToString();
            if (!string.IsNullOrEmpty(durum))
            {
                bool d = Convert.ToBoolean(durum);
                model = model.Where(x => x.Aktif == d);
            }

            var count = model.Count();
            var pager = new Pager(count, page, adet);
            pager.SearchText = searchText;

            model = model.OrderByDescending(x => x.EklemeTarihi);
            //sayfala
            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();

            return PartialView(data);
        }


        [Yetki("Kategoriler", "Skill", "")]
        public IActionResult GetSkill(int id)
        {
            var model = Db.SkillCourseRelation
                .Include(x => x.Skill)
                .Include(x => x.Course)
                .Where(x=> x.CourseId == id)
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

        [Yetki("Kategoriler", "Skill", "")]
        public override JsonResult Save(SkillCourseRelation form)
        {
            return base.Save(form);
        }
    }
}
