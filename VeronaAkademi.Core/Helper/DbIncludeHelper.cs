using System.Reflection;

namespace VeronaAkademi.Core.Helper
{
    public class DbIncludeHelper
    {
        public List<string> Skill()
        {
            var list = new List<string>();
            list.Add("SkillCourseRelation");
            return list;
        }
        public List<string> Lecturer()
        {
            var list = new List<string>();
            list.Add("LecturerCourseRelation");
            return list;
        }
        public List<string> Profession()
        {
            var list = new List<string>();
            list.Add("ProfessionCourseRelation");
            return list;
        }
        public List<string> Course()
        {
            var list = new List<string>();
            list.Add("SkillCourseRelation");
            list.Add("SkillCourseRelation.Skill");
            list.Add("ProfessionCourseRelation");
            list.Add("ProfessionCourseRelation.Profession");
            list.Add("LecturerCourseRelation");
            list.Add("LecturerCourseRelation.Lecturer");
            list.Add("PackageCourseRelation");
            list.Add("PackageCourseRelation.Package");
            return list;
        }
        public List<string> Package()
        {
            var list = new List<string>();
            list.Add("PackageCourseRelation");
            list.Add("PackageCourseRelation.Course");
            list.Add("PackagePracticeLessonRelation");
            list.Add("PackagePracticeLessonRelation.PracticeLesson");
            list.Add("PackageAdvisorRelation");
            list.Add("PackageAdvisorRelation.Advisor");
            return list;
        }
        public List<string> Advisor()
        {
            var list = new List<string>(); 
            list.Add("PackageAdvisorRelation");
            list.Add("PackageAdvisorRelation.Package");
            list.Add("AdvisorCourseRelation");
            list.Add("AdvisorCourseRelation.Course");
            return list;
        }
        public List<string> PracticeLesson()
        {
            var list = new List<string>();
            list.Add("PackagePracticeLessonRelation");
            list.Add("PackagePracticeLessonRelation.Package");
            list.Add("PracticeLessonCourseRelation");
            list.Add("PracticeLessonCourseRelation.Course");
            return list;
        }

        public List<string> GetField(string name)
        {
            try
            {
                MethodInfo mi = this.GetType().GetMethod(name);
                if (mi == null)
                    return null;
                else
                {
                    var list = (List<string>)(mi.Invoke(this, null));
                    return list;
                } 
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }
}
