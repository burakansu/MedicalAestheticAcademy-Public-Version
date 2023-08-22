using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeronaAkademi.Panel.Controllers
{
    public class LessonController : BaseController<Lesson>
    {
        public LessonController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Dersler", "fa-sharp fa-solid fa-paste", "Kurs", 0, 8)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Dersler", "Lesson", "")]
        public override IActionResult GetList(int page = 1, int adet = 5)
        {
            var searchText = "";
            var model = Db.Lesson
                .Include(x => x.Currency)
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => x.Name.Contains(searchText) || x.LessonId.ToString() == searchText);
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


        [Yetki("Dersler", "Lesson", "")]
        public IActionResult GetLesson(int id)
        {
            var model = Db.Lesson
                .Include(x => x.Currency)
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .Where(x => x.Course.CourseId == id)
            .Where(x => !x.Silindi);

            return PartialView(model.ToList());
        }


        [Yetki("Dersler", "Lesson", "")]
        public IActionResult Detail(int id)
        {
            var model = Db.Lesson
                .Include(x => x.Currency)
                .Include(x => x.Course)
                .Single(x => x.LessonId == id);

            return View(model);
        }


        [Yetki("Dersler", "Lesson", "")]
        public IActionResult DetailForm(int id)
        {
            var model = Db.Lesson
                .Include(x => x.Currency)
                .Include(x => x.Course)
                .Single(x => x.LessonId == id);
            return View(model);
        }


        [Yetki("Dersler", "Lesson", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(Db.Lesson.Single(x => x.LessonId == id));
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
        public override JsonResult Save(Lesson form)
        {
            if (form.LessonId == 0)
            {
                form.Image = "-";
            }
            return base.Save(form);
        }

        public void Update(Lesson form)
        {
            form.Aktif = true;
            Db.Lesson.Update(form);
            Db.SaveChanges();
        }
    }
}
