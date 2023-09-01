using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
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
            var model = Db.Review
                .Include(x => x.Lesson)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Customer)
                .Where(x => !x.Deleted)
                .AsQueryable();

            return base.GetListModel(model, page, adet);
        }
    }
}
