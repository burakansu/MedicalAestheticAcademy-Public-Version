using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class MessageController : BaseController<Message>
    {
        public MessageController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [HttpGet]
        public IActionResult Messages(int id)
        {
            var a = Db.CustomerAdvisorRelation
               .Include(x => x.Customer)
               .Include(x => x.Advisor)
               .Single(x => x.CustomerAdvisorRelationId == id);

            var model = Db.Message
                .Include(x => x.Advisor)
                .Include(x => x.Customer)
                .Where(x => x.AdvisorId == a.AdvisorId && x.CustomerId == a.CustomerId)
                .OrderBy(x => x.EklemeTarihi)
                .ToList();

            ViewBag.AdvisorId = a.AdvisorId;
            ViewBag.CustomerId = a.CustomerId;
            return PartialView(model);
        }

        public override JsonResult Save(Message form)
        {
            return base.Save(form);
        }
    }
}
