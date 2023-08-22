using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
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
            var searchText = "";
            //var model = repo.GetAll(x => !x.Silindi);
            var model = Db.Trailer
                .Include(x => x.Course)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => x.Name.Contains(searchText) || x.TrailerId.ToString() == searchText);
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


        [Yetki("Fragmanlar", "Trailer", "")]
        public IActionResult GetTrailer(int id)
        {
            var model = Db.Trailer
                .Include(x => x.Course)
                .Where(x => x.Course.CourseId == id)
                .AsQueryable();

            var data = model.ToList();

            return PartialView(data);
        }

        [Yetki("Beceri Grupları", "SkillGroup", "")]
        public override JsonResult Save(Trailer form)
        {
            return base.Save(form);
        }
    }
}
