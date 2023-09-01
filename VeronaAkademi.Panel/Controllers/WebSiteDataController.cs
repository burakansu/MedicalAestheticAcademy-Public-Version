using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class WebSiteDataController : BaseController<WebSiteData>
    {
        public WebSiteDataController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Web Site Ayarları", "fa-solid fa-gear", "Ayarlar", 0, 99)]
        public IActionResult Index()
        {
            return View(repo.GetAll().First());
        }

        public void Save(WebSiteData data)
        {
            data.UpdateDate = DateTime.Now;
            Db.Update(data);
            Db.SaveChanges();
        }
    }
}
