using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.EntityFramework;

namespace VeronaAkademi.Panel.Controllers
{
    public class CourseController : BaseController<Course>
    {
        public CourseController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
            repo = new CourseRepository();
        }

        [Menu("Kurslar", "fa-solid fa-graduation-cap", "Kurs", 0, 5)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kurslar", "Course", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var model = repo.GetAll();
            var searchText = Request.Query["searchText"].ToString();
            var CourseId = Request.Query["CourseId"].ToString();

            if (!string.IsNullOrEmpty(searchText)) 
                model = model.Where(x => x.Name.Contains(searchText));

            if (!string.IsNullOrEmpty(CourseId)) 
                model = model.Where(x => x.CourseId == Int32.Parse(CourseId));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult GetCourse(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Detail(int id)
        {
            return View(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Lessons(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Trailers(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Skills(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Professions(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Lecturers(int id)
        {
            return PartialView(repo.Get(id));
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(repo.Get(id));
        }

        [HttpPost]
        public IActionResult Upload([FromForm] IFormFile file, [FromForm] int courseId)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/Course", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    file.CopyTo(stream);

                var course = Db.Course.FirstOrDefault(c => c.CourseId == courseId);
                if (course != null)
                {
                    course.Image = fileName;
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }

            return BadRequest("Geçersiz dosya veya kurs bulunamadı!");
        }

        [Yetki("Kurslar", "Course", "")]
        public override JsonResult Kaydet(Course form)
        {
            if (form.CourseId == 0)
                form.Image = "-";

            return base.Kaydet(form);
        }

        public void Update(Course form)
        {
            form.Active = true;
            Db.Course.Update(form);
            Db.SaveChanges();
        }
    }
}
