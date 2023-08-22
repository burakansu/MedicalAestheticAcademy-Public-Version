using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Core.Helper;
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
            var searchText = "";
            var model = repo.GetAll(x => !x.Silindi);

            if (page < 1)
            {
                page = 1;
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => x.Name.Contains(searchText) || x.LecturerId.ToString() == searchText);
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
        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult Detail(int id)
        {
            var model = Db.Lecturer.Single(x => x.LecturerId == id);

            return View(model);
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult DetailForm(int id)
        {
            var model = Db.Lecturer
                .Single(x => x.LecturerId == id);

            return View(model);
        }

        [Yetki("Eğitmenler", "Lecturer", "")]
        public IActionResult ImageForm(int id)
        {
            return PartialView(Db.Lecturer.Single(x => x.LecturerId == id));
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
        public override JsonResult Save(Lecturer form)
        {
            return base.Save(form);
        }

        public void Update(Lecturer form)
        {
            form.Aktif = true;
            Db.Lecturer.Update(form);
            Db.SaveChanges();
        }
    }
}
