
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class PracticeLessonGalleryController : BaseController<PracticeLessonGallery>
    {
        public PracticeLessonGalleryController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }
        public IActionResult GetImages(int id)
        {
            var model = Db.PracticeLessonGallery.Where(x => x.PracticeLessonId == id)
                .Include(x => x.PracticeLesson)
                .Where(x => x.Silindi != true)
                .ToList();

            return PartialView(model);
        }
    }
}
