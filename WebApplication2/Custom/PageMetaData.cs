using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Custom
{
    public class PageMetaData : IPageMetaData
    {
        private Db _db { get; set; }

        public PageMetaData()
        {
            _db = new Db();
        }

        public List<CategoryGroup> baseCategoryGroup()
        {
            return _db.CategoryGroup.ToList();
        }
        public List<Category> baseCategory()
        {
            return _db.Category
                .Include(x => x.CategoryGroup)
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<Skill> baseSkill()
        {
            return _db.Skill
                .Include(x => x.SkillGroup)
                .Include(x => x.SkillCourseRelation)
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<SkillGroup> baseSkillGroup()
        {
            return _db.SkillGroup.ToList();
        }
        public List<Currency> baseCurrency()
        {
            return _db.Currency.ToList();
        }
        public List<CustomerAdvisorRelation> baseCustomerAdvisorRelation()
        {
            return _db.CustomerAdvisorRelation
                .Include(x => x.Advisor)
                .Include(x => x.Customer)
                .ToList();
        }
        public List<Lecturer> baseLecturer()
        {
            return _db.Lecturer.ToList();
        }
        public List<Course> baseCourse()
        {
            return _db.Course
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Include(x => x.Category)
                .Where(x => !x.Silindi)
                .ToList();
        }

        public List<Profession> baseProfession()
        {
            return _db.Profession
                .Include(x => x.ProfessionCourseRelation)
                .ToList();
        }
        public List<CustomerPracticeLessonRelation> baseCustomerPracticeLessonRelation()
        {
            return _db.CustomerPracticeLessonRelation
                .Include(x => x.PracticeLesson)
                    .ThenInclude(x => x.PackagePracticeLessonRelation)
                .Include(x => x.Customer)
                .ToList();
        }
        public List<Lesson> baseLesson()
        {
            return _db.Lesson
                .Include(x => x.Reviews)
                .Include(x => x.Course)
                .Include(x => x.Currency)
                .ToList();
        }
        public List<Trailer> baseTrailer()
        {
            return _db.Trailer
                .Include(x => x.Course)
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<ProfessionCourseRelation> baseProfessionCourseRelation()
        {
            return _db.ProfessionCourseRelation
                .Include(x => x.Course)
                .Include(x => x.Profession)
                .Where(x => !x.Silindi)
                .OrderBy(x => x.GuncellemeTarihi)
                .Take(8)
                .ToList();
        }
        public List<LecturerCourseRelation> baseLecturerCourseRelation()
        {
            return _db.LecturerCourseRelation
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .ToList();
        }
        public List<CustomerCourseRelation> baseCustomerCourseRelation()
        {
            return _db.CustomerCourseRelation
                .Include(x => x.Customer)
                .Include(x => x.Course)
                .ToList();
        }
        public List<CustomerLessonRelation> baseCustomerLessonRelation()
        {
            return _db.CustomerLessonRelation
                .Include(x => x.Customer)
                .Include(x => x.Lesson)
                .ToList();
        }
        public List<Customer> baseCustomer()
        {
            return _db.Customer
                .Include(x => x.Review)
                .ToList();
        }
        public List<Basket> baseBasket()
        {
            return _db.Basket
                .Include(x => x.Product)
                .ToList();
        }
        public List<Order> baseOrder()
        {
            return _db.Order
                .Include(x => x.Product)
                .ToList();
        }
        public List<Review> baseReview()
        {
            return _db.Review
                .Include(x => x.Customer)
                .Include(x => x.Lesson)
                .Include(x => x.Lesson.Course)
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<Package> basePackage()
        {
            return _db.Package
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Course")
                .Include(x => x.PackagePracticeLessonRelation)
                .Include("PackagePracticeLessonRelation.PracticeLesson")
                .Include(x => x.PackageAdvisorRelation)
                .Include("PackageAdvisorRelation.Advisor")
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<Advisor> baseAdvisor()
        {
            return _db.Advisor
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Package)
                .Include(x => x.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Currency)
                .Include(x => x.Lecturer)
                .Where(x => !x.Silindi)
                .ToList();
        }
        public List<CustomerPackageRelation> baseCustomerPackageRelation()
        {
            return _db.CustomerPackageRelation
                .Include(x => x.Package)
                .ToList();
        }
        public List<PracticeLesson> basePracticeLesson()
        {
            return _db.PracticeLesson
            .Include(x => x.PracticeLessonCourseRelation)
                .ThenInclude(x => x.Course)
            .Include(x => x.PackagePracticeLessonRelation)
                .ThenInclude(x => x.Package)
            .Include(x => x.PracticeLessonGallery)
            .Where(x => !x.Silindi)
            .ToList();
        }
        public int baseCustomerId()
        {
            CookieHelper cookieHelper = new CookieHelper();
            string id = cookieHelper.Get("CustomerId");
            if (!string.IsNullOrEmpty(id))
            {
                return Int32.Parse(id);
            }
            return 0;
        }
        public string baseAssetsPath()
        {
            return "https://panel.medicalestheticacedemy.com/assets/Images/";
        }
    }
}
