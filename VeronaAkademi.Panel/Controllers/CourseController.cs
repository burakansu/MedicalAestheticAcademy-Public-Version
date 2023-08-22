using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeronaAkademi.Panel.Controllers
{
    public class CourseController : BaseController<Course>
    {
        public CourseController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Kurslar", "fa-solid fa-graduation-cap", "Kurs", 0, 5)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Kurslar", "Course", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Where(x => !x.Silindi)
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Where(x => !x.Silindi)
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Where(x => !x.Silindi)
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Include(x => x.Category)
                .Where(x => !x.Silindi)
                .AsQueryable();

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model.Where(
                    x => x.Name.Contains(searchText)
                    || x.CourseId.ToString() == searchText
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


            if (!string.IsNullOrEmpty(orderBy))
            {
                var _orderWay = !string.IsNullOrEmpty(orderWay) ? orderWay : "Desc";
                //model = model.OrderBy(orderBy + " " + _orderWay);
                pager.OrderBy = orderBy;
                pager.OrderWay = orderWay;
            }
            else
            {
                model = model.OrderByDescending(x => x.EklemeTarihi);
            }
            //sayfala
            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();

            return PartialView(data);
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult GetCourse(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Where(x => !x.Silindi)
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Where(x => !x.Silindi)
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Where(x => !x.Silindi)
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Include(x => x.Category)
                .Single(x => x.CourseId == id);

            return PartialView(model);
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Detail(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Package")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Single(x => x.CourseId == id);

            return View(model);
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Lessons(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Where(x => x.CourseId == id)
                .Where(x => !x.Silindi)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Trailers(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Where(x => x.CourseId == id)
                .Where(x => !x.Silindi)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Skills(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Where(x => x.CourseId == id)
                .Where(x => !x.Silindi)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Professions(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Where(x => x.CourseId == id)
                .Where(x => !x.Silindi)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult Lecturers(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Where(x => x.CourseId == id)
                .Where(x => !x.Silindi)
                .AsQueryable();

            return PartialView(model.ToList());
        }

        [Yetki("Kurslar", "Course", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(Db.Course.Single(x => x.CourseId == id));
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
                {
                    file.CopyTo(stream);
                }

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
        public override JsonResult Save(Course form)
        {
            if (form.CourseId == 0)
            { 
                form.Image = "-";
            }
                
            return base.Save(form);
        }
        public void Update(Course form)
        {
            form.Aktif = true;
            Db.Course.Update(form);
            Db.SaveChanges();
        }
    }
}
