using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Custom;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class ReviewsController : BaseController<Review>
    {
        public ReviewsController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Yorumlar", "fa-solid fa-message", "Yorumlar", 0, 30)]
        public IActionResult Index()
        {
            return View();
        }
        public virtual JsonResult Approved(int id)
        {
            var response = new Response();
            var model = dbset.Find(id);
            if (model != null)
            {
                var durum = model.Approved == true ? false : true;
                var title = model.Approved == true ? "Onaylanmamış" : "Onaylanmış";
                model.Approved = durum;

                Db.SaveChanges();
                response.Success = true;
                response.Description = "kayıt " + title + " edildi";
                return Json(response);
            }
            response.Success = false;
            response.Description = "kayıt bulunamadı";
            return Json(response);
        }

        [Yetki("Yorumlar", "Review", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = Db.Review
                .Include(x => x.Lesson)
                .Include(x => x.Customer)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(
                    x => x.Lesson.Name.Contains(searchText)
                    || x.ReviewId.ToString() == searchText
                    );
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


            if (!string.IsNullOrEmpty(orderBy))
            {
                var _orderWay = !string.IsNullOrEmpty(orderWay) ? orderWay : "Desc";
                //model = model.OrderBy(orderBy + " " + _orderWay);
                pager.OrderBy = orderBy;
                pager.OrderWay = orderWay;
            }
            else
            {
                model = model.OrderByDescending(x => x.EklemeTarihi);
            }
            //sayfala
            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();

            return PartialView(data);
        }
    }
}
