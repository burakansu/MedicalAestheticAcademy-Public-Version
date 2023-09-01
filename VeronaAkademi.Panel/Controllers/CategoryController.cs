using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        public CategoryController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Kategoriler", "fa-solid fa-rectangle-list", "Kategori", 0, 4)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kategoriler", "Category", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = Db.Category
                .Include(x => x.CategoryGroup)
                .Where(x => !x.Deleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Kategoriler", "Category", "")]
        public override JsonResult Kaydet(Category form)
        {
            return base.Kaydet(form);
        }
    }
}
