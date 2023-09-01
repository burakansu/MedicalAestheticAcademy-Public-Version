using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Data.EntityFramework
{
    public class LessonRepository : GenericRepository<Lesson>
    {
        private IQueryable<Lesson> Includes()
        {
            return dbset
                .Include(x => x.Currency)
                .Include(x => x.Lecturer)
                .Include(x => x.Course)
                .Where(x => !x.Deleted)
                .AsQueryable();
        }

        public override Lesson Get(int id)
        {
            return Includes().FirstOrDefault(x => x.LessonId == id);
        }

        public override Lesson Get(Expression<Func<Lesson, bool>> filter)
        {
            return Includes().FirstOrDefault(filter);
        }

        public override IQueryable<Lesson> GetAll()
        {
            return Includes();
        }

        public override IQueryable<Lesson> GetAll(Expression<Func<Lesson, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}