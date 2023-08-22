using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Custom
{
    public interface IPageMetaData
    {
        List<CategoryGroup> baseCategoryGroup();
        List<Category> baseCategory();
        List<Skill> baseSkill();
        List<SkillGroup> baseSkillGroup();
        List<Currency> baseCurrency();
        List<CustomerAdvisorRelation> baseCustomerAdvisorRelation();
        List<Lecturer> baseLecturer();
        List<Course> baseCourse();
        List<Profession> baseProfession();
        List<CustomerPracticeLessonRelation> baseCustomerPracticeLessonRelation();
        List<Lesson> baseLesson();
        List<Trailer> baseTrailer();
        List<ProfessionCourseRelation> baseProfessionCourseRelation();
        List<LecturerCourseRelation> baseLecturerCourseRelation();
        List<CustomerCourseRelation> baseCustomerCourseRelation();
        List<CustomerLessonRelation> baseCustomerLessonRelation();
        List<Customer> baseCustomer();
        List<Basket> baseBasket();
        public List<Order> baseOrder();
        public List<Review> baseReview();
        List<Package> basePackage();
        List<Advisor> baseAdvisor();
        List<CustomerPackageRelation> baseCustomerPackageRelation();
        List<PracticeLesson> basePracticeLesson();
        int baseCustomerId();
        public string baseAssetsPath();
    }
}
