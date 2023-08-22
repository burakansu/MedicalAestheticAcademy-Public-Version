using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
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
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            var model = Db.PracticeLesson
                .Include(x => x.PracticeLessonCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.PackagePracticeLessonRelation)
                    .ThenInclude(x => x.Package)
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
                    || x.PracticeLessonId.ToString() == searchText
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

           // ViewBag.Pager = pager;
            ViewBag.Toplam = count;
            var data = model.ToList();
            foreach (var practiceLesson in data)
            {
                practiceLesson.PracticeLessonGallery = Db.PracticeLessonGallery
                    .Where(x => x.PracticeLessonId == practiceLesson.PracticeLessonId)
                    .ToList();
            }

            return PartialView(data);
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
                    practiceLessonGallery.EklemeTarihi = DateTime.Now;
                    practiceLessonGallery.Aktif = true;
                    Db.PracticeLessonGallery.Add(practiceLessonGallery);
                    Db.SaveChanges();

                    return Ok("Güncelleme başarılı!");
                }
            }
           
            return BadRequest("Geçersiz dosya!");
        }

        public override JsonResult Save(PracticeLesson form)
        {
            return base.Save(form);
        }
    }
}
