using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Custom;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Panel.Controllers
{
    public class PersonelController : BaseController<Personel>
    {
        public PersonelController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Personel Sayfası", "fa-solid fa-briefcase", "Personel Sayfası", 0, 20)]
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult YetkiForm(int id)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = RestrictionControlActionList();

            List<Restriction> model = new List<Restriction>();
            var kisitlamalar = Db.Restriction.ToList();

            foreach (var ca in controlleractionlist)
            {
                var restriction = kisitlamalar.FirstOrDefault(i => ca.NameSpace == i.NameSpace && ca.Controller == i.Controller && ca.Action == i.Action);
                if (restriction == null)
                {
                    var rs = new Restriction();
                    rs.Description = ca.Attribute.GetType().GetProperty("Description").GetValue(ca.Attribute, null).ToString();
                    rs.Action = ca.Action;
                    rs.Name = "";
                    rs.Controller = ca.Controller;
                    rs.Group = ca.Attribute.GetType().GetProperty("Group").GetValue(ca.Attribute, null).ToString();
                    rs.TargetDivId = ca.Attribute.GetType().GetProperty("TargetDiv").GetValue(ca.Attribute, null).ToString();
                    rs.NameSpace = ca.NameSpace;
                    Db.Restriction.Add(rs);
                    Db.SaveChanges();
                    model.Add(rs);
                }
                else
                {
                    restriction.Description = ca.Attribute.GetType().GetProperty("Description").GetValue(ca.Attribute, null).ToString();
                    restriction.Group = ca.Attribute.GetType().GetProperty("Group").GetValue(ca.Attribute, null).ToString();
                    restriction.TargetDivId = ca.Attribute.GetType().GetProperty("TargetDiv").GetValue(ca.Attribute, null).ToString();
                    model.Add(restriction);
                }
            }

            var personel = repo.Get(id);

            ViewBag.kisitlamalar = model;
            ViewBag.seciliKisitlamalar = Db.PersonelInterfaceRestrictionRelation.Where(i => i.PersonelId == id).Select(i => i.Restriction).ToList();

            return PartialView(personel);
        }
        
        public JsonResult YetkiKaydet(int id, List<int> ids)
        {
            var response = new Response();
            try
            {
                Db.PersonelInterfaceRestrictionRelation.RemoveRange(Db.PersonelInterfaceRestrictionRelation.Where(i => i.PersonelId == id));
                if (ids != null)
                {
                    Db.PersonelInterfaceRestrictionRelation.AddRange(ids.Select(i => new PersonelInterfaceRestrictionRelation
                    {
                        RestrictionId = i,
                        PersonelId = id,
                    }).ToList());
                }
                Db.SaveChanges();
                response.Success = true;
                response.Description = "İşlem başarıyla Gerçekleşti";
            }
            catch (Exception ex)
            {
                response.ex = ex;
                response.Success = true;
                response.Description = "İşlem başarıyla Gerçekleşti";

            }

            return Json(response);
        }
    }
}
