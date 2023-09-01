using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Data.EntityFramework
{
    public class CourseRepository : GenericRepository<Course>
    {
        private IQueryable<Course> Includes()
        {
            return dbset
                .Include(x => x.Currency)
                .Include(x => x.ProfessionCourseRelation)
                .Include("ProfessionCourseRelation.Profession")
                .Where(x => !x.Deleted)
                .Include(x => x.SkillCourseRelation)
                .Include("SkillCourseRelation.Skill")
                .Where(x => !x.Deleted)
                .Include(x => x.LecturerCourseRelation)
                .Include("LecturerCourseRelation.Lecturer")
                .Where(x => !x.Deleted)
                .Include(x => x.Lesson)
                .Include(x => x.Trailer)
                .Include(x => x.Category)
                .Where(x => !x.Deleted)
                .AsQueryable();
        }

        public override Course Get(int id)
        {
            return Includes().FirstOrDefault(x => x.CourseId == id);
        }

        public override Course Get(Expression<Func<Course, bool>> filter)
        {
            return Includes().FirstOrDefault(filter);
        }

        public override IQueryable<Course> GetAll()
        {
            return Includes();
        }

        public override IQueryable<Course> GetAll(Expression<Func<Course, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}