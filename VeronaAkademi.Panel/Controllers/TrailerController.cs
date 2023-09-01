using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeronaAkademi.Panel.Controllers
{
    public class TrailerController : BaseController<Trailer>
    {
        public TrailerController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Fragmanlar", "fa-solid fa-video", "Kurs", 0, 12)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Fragmanlar", "Trailer", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = Db.Trailer
                .Include(x => x.Course)
                .Where(x => !x.Deleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Fragmanlar", "Trailer", "")]
        public IActionResult GetTrailer(int id)
        {
            var model = Db.Trailer
                .Include(x => x.Course)
                .Where(x => x.Course.CourseId == id)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Beceri Grupları", "SkillGroup", "")]
        public override JsonResult Kaydet(Trailer form)
        {
            return base.Kaydet(form);
        }
    }
}
