using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Attributes;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Controllers
{
    public class HomeController : BaseController<Course>
    {
        public HomeController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, httpcontext, webHostEnvironment)
        {
        }

        [Menu("Anasayfa", "fa-solid fa-house fs-3", "Anasayfa", 0, 1)]
        public IActionResult Index()
        {
            DeleteOutSixMonth();

            var model = Db.Course
                .Where(x => !x.Silindi)
                .AsQueryable();

            var data = model.ToList();

            return View(data);
        }

        private void DeleteOutSixMonth()
        {
            var orders = Db.Order
               .Include(x => x.Product)
               .Include(x => x.Customer)
               .Where(x => x.FinishDate <= DateTime.Now && x.IsDeleted ==  false)
               .ToList();

            foreach (var order in orders)
            {
                try
                {
                switch (order.Product.Type)
                {
                    case 1:
                        var customerLessonRelation = Db.CustomerLessonRelation.FirstOrDefault(x => x.LessonId == order.Product.ProductId && x.CustomerId == order.CustomerId);
                        if (customerLessonRelation != null)
                            Db.CustomerLessonRelation.Remove(customerLessonRelation);
                        break;
                    case 2:
                        var customerPackageRelation = Db.CustomerPackageRelation.FirstOrDefault(x => x.PackageId == order.Product.ProductId && x.CustomerId == order.CustomerId);
                        if (customerPackageRelation != null)
                            Db.CustomerPackageRelation.Remove(customerPackageRelation);

                        var courses = Db.PackageCourseRelation
                            .Include(x => x.Course)
                            .Where(x => x.PackageId == order.Product.ProductId)
                            .Select(x => x.Course)
                            .ToList();

                        foreach (var course in courses)
                        {
                            var customerCourseRelation = Db.CustomerCourseRelation.FirstOrDefault(x => x.CourseId == course.CourseId && x.CustomerId == order.CustomerId);
                            if (customerCourseRelation != null)
                                Db.CustomerCourseRelation.Remove(customerCourseRelation);

                            foreach (var lesson in course.Lesson)
                            {
                                if (Db.CustomerLessonRelation.FirstOrDefault(x => x.LessonId == lesson.LessonId && x.CustomerId == order.CustomerId) != null)
                                    Db.CustomerLessonRelation.Remove(Db.CustomerLessonRelation.Single(x => x.LessonId == lesson.LessonId && x.CustomerId == order.CustomerId));
                            }
                        }

                        var advisors = Db.CustomerAdvisorRelation
                            .Include(x => x.Advisor)
                            .Where(x => x.AdvisorId == order.Product.ProductId)
                            .Select(x => x.Advisor)
                            .ToList();

                        foreach (var advisor in advisors)
                        {
                            if (Db.CustomerAdvisorRelation.FirstOrDefault(x => x.AdvisorId == advisor.AdvisorId && x.CustomerId == order.CustomerId) != null)
                                Db.CustomerAdvisorRelation.Remove(Db.CustomerAdvisorRelation.Single(x => x.AdvisorId == advisor.AdvisorId && x.CustomerId == order.CustomerId));
                        }
                        break;
                    case 3:
                        var customerAdvisorRelation = Db.CustomerAdvisorRelation.FirstOrDefault(x => x.AdvisorId == order.Product.ProductId && x.CustomerId == order.CustomerId);
                        if (customerAdvisorRelation != null)
                            Db.CustomerAdvisorRelation.Remove(customerAdvisorRelation);
                        break;
                }

                order.IsDeleted = true;
                Db.Order.Update(order);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            Db.SaveChanges();
        }

    }
}