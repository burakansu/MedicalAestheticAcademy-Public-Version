using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Data.EntityFramework
{
    public class AdvisorRepository : GenericRepository<Advisor>
    {
        private IQueryable<Advisor> Includes()
        {
            return dbset
                .Include(x => x.Lecturer)
                .Include(x => x.Currency)
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Package)
                .Include(x => x.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Where(x => !x.Deleted)
                .AsQueryable();
        }

        public override Advisor Get(int id)
        {
            return Includes().FirstOrDefault(x => x.AdvisorId == id);
        }

        public override Advisor Get(Expression<Func<Advisor, bool>> filter)
        {
            return Includes().FirstOrDefault(filter);
        }

        public override IQueryable<Advisor> GetAll()
        {
            return Includes();
        }

        public override IQueryable<Advisor> GetAll(Expression<Func<Advisor, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}