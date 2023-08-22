using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Panel.Custom
{
    public interface IPageMetaData
    {
        string PageTitle { get; set; }
        string PageDescription { get; set; }
        string[] BodyCssClasses { get; set; }
        public List<BaseMenu> baseMenu(string pre, string nameSpace);
        public string ScriptVersion();
        public string EnvironmentVersion();
        List<CategoryGroup> baseCategoryGroup();
        List<Category> baseCategory();
        List<Skill> baseSkill();
        List<SkillGroup> baseSkillGroup();
        List<Currency> baseCurrency();
        List<Lecturer> baseLecturer();
        List<Course> baseCourse();
        List<Profession> baseProfession();
        List<Lesson> baseLesson();
        List<Trailer> baseTrailer();
        List<Package> basePackage();
        List<Advisor> baseAdvisor();
        List<PracticeLesson> basePracticeLesson();
        List<Customer> baseCustomer();
        List<Order> baseOrder();
        public string baseAssetsPath();

    }
}
