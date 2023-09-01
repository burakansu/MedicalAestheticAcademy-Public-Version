using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Controllers
{
    public class RegisterUiController : Controller
    {
        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null)
                    _db = new Db();
                
                return _db;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            try
            {
                customer.CurrencyId = 1;
                customer.CreateDate = DateTime.Now;
                customer.Active = true;
                customer.Deleted = false;
                if (customer.Image == null)
                    customer.Image = "AvatarNull.png";
                Db.Customer.Add(customer);
                Db.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
