using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class AdvisorController : BaseController<Advisor>
    {
        public AdvisorController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Danışmanlık Ve Hizmetler", "fa-solid fa-headphones", "Danışmanlık", 0, 13)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = Db.Advisor
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Package)
                .Include(x => x.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Currency)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(
                    x => x.AdvisorId.ToString().Contains(searchText)
                    || x.AdvisorId.ToString() == searchText
                    );
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


            if (!string.IsNullOrEmpty(orderBy))
            {
                var _orderWay = !string.IsNullOrEmpty(orderWay) ? orderWay : "Desc";
                //model = model.OrderBy(orderBy + " " + _orderWay);
                pager.OrderBy = orderBy;
                pager.OrderWay = orderWay;
            }
            else
            {
                model = model.OrderByDescending(x => x.EklemeTarihi);
            }
            //sayfala
            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();
            foreach (var advisor in data)
            {
                advisor.AdvisorCourseRelation = Db.AdvisorCourseRelation
                    .Where(x => x.AdvisorId == advisor.AdvisorId)
                    .ToList();
            }

            return PartialView(data);
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public IActionResult Message(int id)
        {
            var model = Db.CustomerAdvisorRelation
                .Include(x => x.Customer)
                .Include(x => x.Advisor)
                .Where(x=>x.AdvisorId == id)
                .ToList();

            return View(model);
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public IActionResult Chat(int id)
        {
            var a = Db.CustomerAdvisorRelation
                .Include(x => x.Customer)
                .Include(x => x.Advisor)
                .Single(x => x.CustomerAdvisorRelationId == id);

            var model = Db.Message
                .Include(x=>x.Advisor)
                .Include(x => x.Customer)
                .Where(x=>x.AdvisorId == a.AdvisorId && x.CustomerId == a.CustomerId)
                .OrderBy(x=>x.EklemeTarihi)
                .ToList();

            ViewBag.Ids = id;
            ViewBag.AdvisorIds = a.AdvisorId;
            ViewBag.CustomerIds = a.CustomerId;
            return View(model);
        }

        public override JsonResult Save(Advisor form)
        {
            return base.Save(form);
        }
    }
}
