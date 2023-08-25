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
            return View(Db.WebSiteData.First());
        }
        public void Save(WebSiteData data)
        {
            data.GuncellemeTarihi =DateTime.Now;
            Db.Update(data);
            Db.SaveChanges();
        }
    }
}
