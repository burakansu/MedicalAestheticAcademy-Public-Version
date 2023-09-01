using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
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
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var model = repo.GetAll();
            var searchText = Request.Query["searchText"].ToString();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Uzmanlık Alanları", "Profession", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(repo.Get(id));
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
        public override JsonResult Kaydet(Profession form)
        {
            return base.Kaydet(form);
        }
    }
}
