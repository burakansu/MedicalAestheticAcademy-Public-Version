using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Müşteriler", "fa-solid fa-user", "Customer", 0, 6)]
        public IActionResult Index()
        {
            return View();
        }


        [Yetki("Müşteriler", "Customer", "")]
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
                    .Where(x => x.NameSurname.Contains(searchText) || x.CustomerId.ToString() == searchText);
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

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult Detail(int id)
        {
            var model = Db.Customer.Single(x => x.CustomerId == id);

            return View(model);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult DetailForm(int id)
        {
            var model = Db.Customer
                .Single(x => x.CustomerId == id);

            return PartialView(model);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult GetLesson(int id)
        {
            var model = Db.Order
                .Where(x => x.CustomerId == id)
                .ToList();

            ViewBag.customerid = id;

            return PartialView(model);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult GetOrder(int id)
        {
            var model = Db.Order
                .Where(x => x.CustomerId == id)
                .Include(x => x.Customer)
                .ToList();

            ViewBag.customerid = id;

            return PartialView(model);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public override JsonResult Save(Customer form)
        {
            if (form.CurrencyId == 0)
                form.CurrencyId = 1;

            return base.Save(form);
        }
    }
}
