using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Controllers
{
    public class CustomerUiController : Controller
    {
        CookieHelper cookieHelper = new CookieHelper();
        
        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new Db();
                }
                return _db;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyLessons()
        {
            return PartialView();
        }
        public IActionResult MyOrderHistory()
        {
            return PartialView();
        }
        public IActionResult MyReviews()
        {
            return PartialView();
        }
        public IActionResult MyPackages()
        {
            return PartialView();
        }
        public IActionResult MyPracticeLessons()
        {
            return PartialView();
        }
        public IActionResult Profile()
        {
            return PartialView();
        }
        public IActionResult Settings()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SaveProfile(Customer model)
        {
            int CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));
            Customer customer = Db.Customer.Single(x=>x.CustomerId == CustomerId);
            customer.NameSurname = model.NameSurname;
            customer.Email = model.Email;
            customer.PhoneNumber = model.PhoneNumber;
            Db.Customer.Update(customer);
            Db.SaveChanges();

            return Json(new { success = true, message = "Profil kaydedildi." });
        }

        [HttpPost]
        public ActionResult SavePassword(Customer model)
        {
            int CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));
            Customer customer = Db.Customer.Single(x => x.CustomerId == CustomerId);
            customer.Password = model.Password;
            Db.Customer.Update(customer);
            Db.SaveChanges();

            return Json(new { success = true, message = "Parola kaydedildi." });
        }

        [HttpPost]
        public IActionResult SaveImage([FromForm] IFormFile file)
        {
            int CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));
            Customer customer = Db.Customer.Single(x => x.CustomerId == CustomerId);
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/Customer", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                if (customer != null)
                {
                    customer.Image = fileName;
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }

            return BadRequest("Geçersiz dosya veya kurs bulunamadı!");
        }
    }
}
