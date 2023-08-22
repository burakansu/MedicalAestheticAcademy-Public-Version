using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class ProfessionCourseRelationController : BaseController<ProfessionCourseRelation>
    {
        public ProfessionCourseRelationController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        //[Menu("Kurs-Uzmanlık", "fa-sharp fa-solid fa-link", "İlişkilendirme", 5, 5)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kategoriler", "Profession", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = "";
            var model = Db.ProfessionCourseRelation
                .Include(x => x.Profession)
                .Include(x => x.Course)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(x => x.ProfessionCourseRelationId.ToString() == searchText);
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

            var data = model.ToList();

            return PartialView(data);
        }


        [Yetki("Kategoriler", "Profession", "")]
        public override JsonResult Save(ProfessionCourseRelation form)
        {
            return base.Save(form);
        }
    }
}
