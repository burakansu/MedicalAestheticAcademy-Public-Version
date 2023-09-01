using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Ui.Models;

namespace VeronaAkademi.Ui.Controllers
{
    public class CourseUiController : Controller
    {
        CookieHelper cookieHelper = new CookieHelper();
        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null)
                {
                    _db = new Db();
                }
                return _db;
            }
        }

        public IActionResult Index(int categoryid = 0, int skillid = 0, int professionid = 0, int lecturerid = 0)
        {
            HomeViewModel model = new HomeViewModel();

            model.Filter = 0;

            if (categoryid > 0)
            {
                model.Filter = 1;
                model.id = categoryid;
            }

            else if (skillid > 0)
            {
                model.Filter = 2;
                model.id = skillid;
            }
            else if (professionid > 0)
            {
                model.Filter = 3;
                model.id = professionid;
            }
            else if (lecturerid > 0)
            {
                model.Filter = 4;
                model.id = lecturerid;
            }

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = Db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include(x => x.PackageCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Include(x => x.Category)
                .Where(x => !x.Deleted)
                .Single(x => x.CourseId == id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Reviews(int id)
        {
            Course model = null;
            if (id != 0)
                model = Db.Course.Single(x => x.CourseId == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Review(Review review)
        {
            review.Active = true;
            review.CreateDate = DateTime.Now;
            review.CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));

            try
            {
                Db.Review.Add(review);
                Db.SaveChanges();
                return Ok("İnceleme başarıyla kaydedildi.");
            }
            catch (Exception)
            {
                return BadRequest("İnceleme kaydedilemedi. Lütfen geçerli bir form gönderin.");
                throw;
            }
        }

        [HttpPost]
        public IActionResult SideBarLesson(int id)
        {
            var model = Db.Lesson
                .Include(x => x.Course)
                .Include(x => x.Basket)
                .Include(x => x.Currency)
                .Where(i => i.CourseId == id).ToList();
            var f = Request.Form;

            return View(model);
        }

        public IActionResult ViewCourse(int lessonid)
        {
            int CustomerId = Int32.Parse(cookieHelper.Get("CustomerId"));

            if (lessonid != 0)
            {
                CustomerLessonRelation customerLessonRelation = Db.CustomerLessonRelation.FirstOrDefault(x => x.LessonId == lessonid && x.CustomerId == CustomerId);
                customerLessonRelation.Completed = 1;
                Db.CustomerLessonRelation.Update(customerLessonRelation);
                Db.SaveChanges();

                var courseid = Db.Lesson.Single(x => x.LessonId == lessonid).CourseId;
                var course = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == courseid);
                if (Db.CustomerCourseRelation.Where(x => x.CourseId == courseid && x.CustomerId == CustomerId).Count() == 0)
                {
                    CustomerCourseRelation customerCourseRelation = new CustomerCourseRelation();
                    customerCourseRelation.CustomerId = CustomerId;
                    customerCourseRelation.CourseId = courseid;
                    customerCourseRelation.Completed = 0;
                    Db.CustomerCourseRelation.Add(customerCourseRelation);
                    Db.SaveChanges();
                }

                int customercourselessoncount = 0;
                foreach (var lesson in course.Lesson)
                {
                    if (Db.CustomerLessonRelation.Where(x => x.LessonId == lesson.LessonId && x.CustomerId == CustomerId && x.Completed == 1).Count() > 0)
                        customercourselessoncount++;
                }
                if (customercourselessoncount == course.Lesson.Count())
                {
                    var customerCourseRelation = Db.CustomerCourseRelation.Single(x => x.CourseId == courseid && x.CustomerId == CustomerId);
                    customerCourseRelation.Completed = 1;
                    Db.CustomerCourseRelation.Update(customerCourseRelation);
                    Db.SaveChanges();
                }
            }

            ViewBag.LessonId = lessonid;

            return View();
        }

    }
}
