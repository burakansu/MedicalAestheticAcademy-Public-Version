using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;
using System.Linq.Dynamic.Core;

namespace VeronaAkademi.Panel.Controllers
{
    public class TestController : BaseController<TestEntity>
    {
        public TestController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {

        }

        
        //[Menu("Test Sayfası", "fa-solid fa-vial-virus fs-3", "Test Sayfası", 0, 2)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Test Listesi", "TEST", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = repo.GetAll(x => !x.Silindi);

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(
                    x => x.Name.Contains(searchText)
                    || x.Id.ToString() == searchText
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
                model = model.OrderBy(orderBy + " " + _orderWay);
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

            return PartialView(data);
        }

        //[Yetki("Test Form", "TEST","")]
        //public override IActionResult Form(int id = 0)
        //{
        //    return base.Form(id);
        //}

        [Yetki("Test Partial", "TEST","TestPartialYetkiDivId")]
        public IActionResult TestPartial()
        {
            return PartialView();
        }

        public override void RestrictionFix(string pre = "Yetki", string nameSpace = "VeronaAkademi.Panel.Controllers")
        {
            base.RestrictionFix(pre, nameSpace);
        }
    }
}
