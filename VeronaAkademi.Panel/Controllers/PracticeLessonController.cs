using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class PracticeLessonController : BaseController<PracticeLesson>
    {
        public PracticeLessonController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }
        [Menu("Pratik Dersler", "fa-solid fa-person-chalkboard", "Pratik Dersler", 0, 14)]
        public IActionResult Index()
        {
            return View();
        }

        [Yetki("Pratik Dersler", "PracticeLesson", "")]
        public override IActionResult GetList(int page = 1, int adet = 10)
        {
            var searchText = Request.Query["searchText"].ToString();
            var model = Db.PracticeLesson
                .Include(x => x.PracticeLessonCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.PackagePracticeLessonRelation)
                    .ThenInclude(x => x.Package)
                .Where(x => !x.Deleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
                model = model.Where(x => x.Name.Contains(searchText));

            return base.GetListModel(model, page, adet);
        }

        [Yetki("Pratik Dersler", "PracticeLesson", "")]
        public IActionResult Detail(int id)
        {
            var model = Db.PracticeLesson.Single(x => x.PracticeLessonId == id);

            return View(model);
        }

        [Yetki("Pratik Dersler", "PracticeLesson", "")]
        public IActionResult ImageForm(int id)
        {
            ViewBag.Id = id;
            return PartialView();
        }
        

        [HttpPost]
        public IActionResult Upload([FromForm] IFormFile file, [FromForm] int PracticeLessonId)
        {
            if (file != null && file.Length > 0)
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("wwwroot/assets/Images/PracticeLesson", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var PracticeLesson = Db.PracticeLesson.FirstOrDefault(c => c.PracticeLessonId == PracticeLessonId);
                PracticeLessonGallery practiceLessonGallery = new PracticeLessonGallery();
                if (PracticeLesson != null)
                {
                    practiceLessonGallery.Image = fileName;
                    practiceLessonGallery.PracticeLessonId = PracticeLessonId;
                    practiceLessonGallery.CreateDate = DateTime.Now;
                    practiceLessonGallery.Active = true;
                    Db.PracticeLessonGallery.Add(practiceLessonGallery);
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }
           
            return BadRequest("Geçersiz dosya!");
        }

        public override JsonResult Kaydet(PracticeLesson form)
        {
            return base.Kaydet(form);
        }
    }
}
