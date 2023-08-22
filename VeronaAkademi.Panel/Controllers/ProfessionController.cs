using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class ProfessionController : BaseController<Profession>
    {
        public ProfessionController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Uzmanlık Alanları", "fa-sharp fa-solid fa-bolt", "Profession", 0, 9)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Uzmanlık Alanları", "Profession", "")]
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
                    .Where(x => x.Name.Contains(searchText) || x.ProfessionId.ToString() == searchText);
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

        [Yetki("Uzmanlık Alanları", "Profession", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(Db.Profession.Single(x => x.ProfessionId == id));
        }

        [HttpPost]
        public IActionResult Upload([FromForm] IFormFile file, [FromForm] int professionId)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/Profession", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var Profession = Db.Profession.FirstOrDefault(c => c.ProfessionId == professionId);
                if (Profession != null)
                {
                    Profession.Image = fileName;
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }

            return BadRequest("Geçersiz dosya veya kurs bulunamadı!");
        }

        [Yetki("Uzmanlık Alanları", "Profession", "")]
        public override JsonResult Save(Profession form)
        {
            return base.Save(form);
        }
    }
}
