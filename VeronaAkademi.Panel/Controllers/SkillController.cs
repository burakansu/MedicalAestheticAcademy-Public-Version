using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeronaAkademi.Panel.Controllers
{
    public class SkillController : BaseController<Skill>
    {
        public SkillController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Beceriler", "fa-solid fa-atom", "Beceri", 1, 5)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Beceriler", "Skill", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = "";

            var model = Db.Skill
                .Include(x => x.SkillGroup)
                .Include(x => x.SkillCourseRelation)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => x.Name.Contains(searchText) || x.SkillId.ToString() == searchText);
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


        [Yetki("Beceriler", "Skill", "")]
        public override JsonResult Save(Skill form)
        {
            return base.Save(form);
        }
    }
}
