using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
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
            var searchText = Request.Query["searchText"].ToString();
            var model = Db.Skill
                .Include(x => x.SkillGroup)
                .Include(x => x.SkillCourseRelation)
                .Where(x => !x.Deleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Beceriler", "Skill", "")]
        public override JsonResult Kaydet(Skill form)
        {
            return base.Kaydet(form);
        }
    }
}
