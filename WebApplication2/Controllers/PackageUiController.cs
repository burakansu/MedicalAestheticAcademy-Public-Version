using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Ui.Custom;

namespace WebApplication2.Controllers
{
    public class PackageUiController : Controller
    {

        public IActionResult Index()
        {
            return View(new PageMetaData().basePackage());
        }

        public IActionResult Detail(int id)
        {
            return View(new PageMetaData().basePackage()
                .Single(x => x.PackageId == id));
        }
    }
}
