using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Data.EntityFramework
{
    public class PackageRepository : GenericRepository<Package>
    {
        private IQueryable<Package> Includes()
        {
            return dbset
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                .Include("PackageCourseRelation.Course")
                .Include(x => x.PackagePracticeLessonRelation)
                .Include("PackagePracticeLessonRelation.PracticeLesson")
                .Include(x => x.PackageAdvisorRelation)
                .Include("PackageAdvisorRelation.Advisor")
                .Where(x => !x.Deleted)
                .AsQueryable();
        }

        public override Package Get(int id)
        {
            return Includes().FirstOrDefault(x => x.PackageId == id);
        }

        public override Package Get(Expression<Func<Package, bool>> filter)
        {
            return Includes().FirstOrDefault(filter);
        }

        public override IQueryable<Package> GetAll()
        {
            return Includes();
        }

        public override IQueryable<Package> GetAll(Expression<Func<Package, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}