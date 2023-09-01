using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
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
        public override JsonResult Kaydet(CategoryGroup form)
        {
            return base.Kaydet(form);
        }
    }
}
