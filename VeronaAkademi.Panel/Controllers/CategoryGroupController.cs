using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class CategoryGroupController : BaseController<CategoryGroup>
    {
        public CategoryGroupController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Kategori Grupları", "fa-sharp fa-solid fa-list-ul", "Kategori", 1, 1)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kategori Grupları", "CategoryGroup", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = "";
            var model = repo.GetAll(x => !x.Silindi);

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => x.Name.Contains(searchText) || x.CategoryGroupId.ToString() == searchText);
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


        [Yetki("Kategori Grupları", "CategoryGroup", "")]
        public override JsonResult Save(CategoryGroup form)
        {
            return base.Save(form);
        }
    }
}
