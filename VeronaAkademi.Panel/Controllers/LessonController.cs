using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.EntityFramework;

namespace VeronaAkademi.Panel.Controllers
{
    public class LessonController : BaseController<Lesson>
    {
        public LessonController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
            repo = new LessonRepository();
        }

        [Menu("Dersler", "fa-sharp fa-solid fa-paste", "Kurs", 0, 8)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Dersler", "Lesson", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = repo.GetAll();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Dersler", "Lesson", "")]
        public IActionResult GetLesson(int id)
        {
            return PartialView(repo.GetAll().Where(x => x.CourseId == id).ToList());
        }

        [Yetki("Dersler", "Lesson", "")]
        public IActionResult Detail(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Dersler", "Lesson", "")]
        public IActionResult DetailForm(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Dersler", "Lesson", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(repo.Get(id));
        }

        [HttpPost]
        public IActionResult Upload([FromForm] IFormFile file, [FromForm] int lessonId)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/Lesson", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var course = Db.Lesson.FirstOrDefault(c => c.LessonId == lessonId);
                if (course != null)
                {
                    course.Image = fileName;
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }

            return BadRequest("Geçersiz dosya veya kurs bulunamadı!");
        }

        [Yetki("Dersler", "Lesson", "")]
        public override JsonResult Kaydet(Lesson form)
        {
            if (form.LessonId == 0)
            {
                form.Image = "-";
            }
            return base.Kaydet(form);
        }

        public void Update(Lesson form)
        {
            form.Active = true;
            Db.Lesson.Update(form);
            Db.SaveChanges();
        }
    }
}
