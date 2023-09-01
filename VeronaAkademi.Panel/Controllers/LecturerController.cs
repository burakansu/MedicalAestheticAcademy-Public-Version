using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class LecturerController : BaseController<Lecturer>
    {
        public LecturerController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Eğitmenler", "fa-solid fa-chalkboard-user", "Lecturer", 0, 7)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult Detail(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult DetailForm(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(repo.Get(id));
        }

        [HttpPost]
        public IActionResult Upload([FromForm] IFormFile file, [FromForm] int lecturerId)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/Lecturer", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var lecturer = Db.Lecturer.First(c => c.LecturerId == lecturerId);
                if (lecturer != null)
                {
                    lecturer.Image = fileName;
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }

            return BadRequest("Geçersiz dosya veya kurs bulunamadı!");
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public override JsonResult Kaydet(Lecturer form)
        {
            return base.Kaydet(form);
        }

        public void Update(Lecturer form)
        {
            form.Active = true;
            Db.Lecturer.Update(form);
            Db.SaveChanges();
        }
    }
}
