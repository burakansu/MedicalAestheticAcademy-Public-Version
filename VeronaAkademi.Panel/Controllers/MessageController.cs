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
            var relation = Db.CustomerAdvisorRelation
               .Include(x => x.Customer)
               .Include(x => x.Advisor)
               .Single(x => x.CustomerAdvisorRelationId == id);

            var model = Db.Message
                .Include(x => x.Advisor)
                .Include(x => x.Customer)
                .Where(x => x.AdvisorId == relation.AdvisorId && x.CustomerId == relation.CustomerId)
                .OrderBy(x => x.CreateDate)
                .ToList();

            ViewBag.AdvisorId = relation.AdvisorId;
            ViewBag.CustomerId = relation.CustomerId;
            return PartialView(model);
        }

        public override JsonResult Kaydet(Message form)
        {
            return base.Kaydet(form);
        }
    }
}
