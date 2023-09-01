using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.EntityFramework;

namespace VeronaAkademi.Panel.Controllers
{
    public class AdvisorController : BaseController<Advisor>
    {
        public AdvisorController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
            repo = new AdvisorRepository();
        }

        [Menu("Danışmanlık Ve Hizmetler", "fa-solid fa-headphones", "Danışmanlık", 0, 13)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public IActionResult Message(int id)
        {
            var model = Db.CustomerAdvisorRelation
                .Include(x => x.Customer)
                .Include(x => x.Advisor)
                .Where(x=>x.AdvisorId == id)
                .ToList();

            return View(model);
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public IActionResult Chat(int id)
        {
            var a = Db.CustomerAdvisorRelation
                .Include(x => x.Customer)
                .Include(x => x.Advisor)
                .Single(x => x.CustomerAdvisorRelationId == id);

            var model = Db.Message
                .Include(x=>x.Advisor)
                .Include(x => x.Customer)
                .Where(x=>x.AdvisorId == a.AdvisorId && x.CustomerId == a.CustomerId)
                .OrderBy(x=>x.CreateDate)
                .ToList();

            ViewBag.Ids = id;
            ViewBag.AdvisorIds = a.AdvisorId;
            ViewBag.CustomerIds = a.CustomerId;
            return View(model);
        }

        [Yetki("Danışmanlık", "Advisor", "")]
        public override JsonResult Kaydet(Advisor form)
        {
            return base.Kaydet(form);
        }
    }
}
