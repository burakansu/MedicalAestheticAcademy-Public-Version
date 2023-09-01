using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
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
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var model = repo.GetAll();
            var searchText = Request.Query["searchText"].ToString();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.NameSurname.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult Detail(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult DetailForm(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult GetLesson(int id)
        {
            var list = new List<Lesson>();
            var model = Db.Order
                .Where(x => x.CustomerId == id)
                .Include(x=>x.Product)
                .ToList();

            foreach (var item in model)
            {
                if (Db.Lesson.Where(x => x.LessonId == item.Product.ProductId).Count() > 0)
                {
                    list.Add(Db.Lesson.Include(x => x.Course).Single(x => x.LessonId == item.Product.ProductId));
                }
            }

            ViewBag.customerid = id;
            return PartialView(list);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public IActionResult GetOrder(int id)
        {
            var model = Db.Order
                .Where(x => x.CustomerId == id)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .ToList();

            ViewBag.customerid = id;
            return PartialView(model);
        }

        [Yetki("Müşteriler", "Customer", "")]
        public override JsonResult Kaydet(Customer form)
        {
            if (form.CurrencyId == 0)
                form.CurrencyId = 1;

            return base.Kaydet(form);
        }
    }
}
