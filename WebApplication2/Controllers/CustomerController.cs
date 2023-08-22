using Microsoft.AspNetCore.Mvc;

namespace VeronaAkademi.Ui.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
