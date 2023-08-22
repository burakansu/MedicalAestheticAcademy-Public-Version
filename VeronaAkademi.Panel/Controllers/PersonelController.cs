using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
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

        [Yetki("Personel Listesi", "Personel", "")]
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
                model = model.Where(
                    x => x.Adi.Contains(searchText)
                    || x.PersonelId.ToString() == searchText
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

            model = model.OrderByDescending(x => x.EklemeTarihi);
            //sayfala
            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();

            return PartialView(data);
        }

        public PartialViewResult YetkiForm(int id)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = RestrictionControlActionList();

            List<Restriction> model = new List<Restriction>();
            var kisitlamalar = Db.Kisitlama.ToList();

            foreach (var ca in controlleractionlist)
            {
                var kisitlama = kisitlamalar.FirstOrDefault(i => ca.NameSpace == i.NameSpace && ca.Controller == i.Controller && ca.Action == i.Action);
                if (kisitlama == null)
                {
                    var ks = new Restriction();
                    ks.Description = ca.Attribute.GetType().GetProperty("Description").GetValue(ca.Attribute, null).ToString();
                    ks.Action = ca.Action;
                    ks.Name = "";
                    ks.Controller = ca.Controller;
                    ks.Grup = ca.Attribute.GetType().GetProperty("Group").GetValue(ca.Attribute, null).ToString();
                    ks.TargetDivId = ca.Attribute.GetType().GetProperty("TargetDiv").GetValue(ca.Attribute, null).ToString();
                    ks.NameSpace = ca.NameSpace;
                    Db.Kisitlama.Add(ks);
                    Db.SaveChanges();
                    model.Add(ks);
                }
                else
                {
                    kisitlama.Description = ca.Attribute.GetType().GetProperty("Description").GetValue(ca.Attribute, null).ToString();
                    kisitlama.Grup = ca.Attribute.GetType().GetProperty("Group").GetValue(ca.Attribute, null).ToString();
                    kisitlama.TargetDivId = ca.Attribute.GetType().GetProperty("TargetDiv").GetValue(ca.Attribute, null).ToString();
                    model.Add(kisitlama);
                }
            }


            var personel = repo.Get(id);

            ViewBag.kisitlamalar = model;
            ViewBag.seciliKisitlamalar = Db.PersonelKisitlamaRelation.Where(i => i.PersonelId == id).Select(i => i.Kisitlama).ToList();

            return PartialView(personel);
        }
        //[Yetki("Personel Yetkilendirmesi Kaydet", "Personel")]
        public JsonResult YetkiKaydet(int id, List<int> ids)
        {
            var response = new Response();
            try
            {
                Db.PersonelKisitlamaRelation.RemoveRange(Db.PersonelKisitlamaRelation.Where(i => i.PersonelId == id));
                if (ids != null)
                {
                    Db.PersonelKisitlamaRelation.AddRange(ids.Select(i => new PersonelRestrictionRelation
                    {
                        KisitlamaId = i,
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
