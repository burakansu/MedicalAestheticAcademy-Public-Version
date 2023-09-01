using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class SkillGroupController : BaseController<SkillGroup>
    {
        public SkillGroupController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Beceri Grupları", "fa-sharp fa-solid fa-list-ul", "Beceri", 0, 11)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Beceri Grupları", "SkillGroup", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Beceri Grupları", "SkillGroup", "")]
        public override JsonResult Kaydet(SkillGroup form)
        {
            return base.Kaydet(form);
        }
    }
}
