
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Panel.Custom
{
    public class PageMetaData : IPageMetaData
    {
        private Db _db { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string[] BodyCssClasses { get; set; }

        public PageMetaData()
        {
            _db = new Db();
        }


        public List<BaseMenu> baseMenu(string pre = "Menu", string nameSpace = "VeronaAkademi.Panel.Controllers")
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace == nameSpace)
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
                        Attribute = x.GetCustomAttributes().FirstOrDefault(f => f.GetType().Name == pre + "Attribute"),
                        NameSpace = nameSpace
                    })
                    .Where(x => x.Attributes.Contains(pre))
                    .Select(x => new BaseMenu
                    {
                        Parent = x.Attribute.GetType().GetProperty("Parent")?.GetValue(x.Attribute, null).ToString(),
                        Title = x.Attribute.GetType().GetProperty("Title")?.GetValue(x.Attribute, null).ToString(),
                        Icon = x.Attribute.GetType().GetProperty("Icon")?.GetValue(x.Attribute, null).ToString(),
                        Order = Convert.ToInt32(x.Attribute.GetType().GetProperty("tybat")?.GetValue(x.Attribute, null).ToString()),
                        ParentOrder = Convert.ToInt32(x.Attribute.GetType().GetProperty("ParentOrder")?.GetValue(x.Attribute, null).ToString()),
                        Url = "/" + x.Controller.Replace("Controller", "") + "/" + x.Action,
                    })
                    .OrderBy(x => x.ParentOrder)
                    .ThenBy(x => x.Order)
                    .ToList();
            return controlleractionlist;


        }
        public string EnvironmentVersion()
        {
            throw new NotImplementedException();
        }
        public string ScriptVersion()
        {
            throw new NotImplementedException();
        }
        public List<CategoryGroup> baseCategoryGroup()
        {
            return _db.CategoryGroup.ToList();
        }
        public List<Category> baseCategory()
        {
            return _db.Category.ToList();
        }
        public List<Skill> baseSkill()
        {
            return _db.Skill.ToList();
        }
        public List<SkillGroup> baseSkillGroup()
        {
            return _db.SkillGroup.ToList();
        }
        public List<Currency> baseCurrency()
        {
            return _db.Currency.ToList();
        }
        public List<Lecturer> baseLecturer()
        {
            return _db.Lecturer.ToList();
        }
        public List<Course> baseCourse()
        {
            return _db.Course.ToList();
        }
        public List<Profession> baseProfession()
        {
            return _db.Profession.ToList();
        }
        public List<Lesson> baseLesson()
        {
            return _db.Lesson.ToList();
        }
        public List<Trailer> baseTrailer()
        {
            return _db.Trailer.ToList();
        }
        public List<Package> basePackage()
        {
            return _db.Package.ToList();
        }
        public List<Advisor> baseAdvisor()
        {
            return _db.Advisor
                .Include(x=>x.Lecturer)
                .ToList();
        }
        public List<PracticeLesson> basePracticeLesson()
        {
            return _db.PracticeLesson.ToList();
        }
        public List<Customer> baseCustomer()
        {
            return _db.Customer.ToList();
        }
        public List<Order> baseOrder()
        {
            return _db.Order
                .ToList();
        }
        public string baseAssetsPath()
        {
            return "https://localhost:7266/assets/Images/";
        }
    }
}
