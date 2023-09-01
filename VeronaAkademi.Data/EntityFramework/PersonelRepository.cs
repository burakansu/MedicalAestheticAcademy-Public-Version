using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.EntityFramework
{
    public class PersonelRepository:GenericRepository<Personel>
    {
        private IQueryable<Personel> Includes()
        {
            var models = dbset
                .Include(x=>x.Department)
                .Include(x=>x.PersonelType)
                .AsQueryable();
            return models;
        }

        public override Personel Get(int id)
        {
            return Includes().FirstOrDefault(x => x.PersonelId == id);
        }

        public override Personel Get(Expression<Func<Personel, bool>> filter)
        {
            return Includes().FirstOrDefault(filter);
        }

        public override IQueryable<Personel> GetAll()
        {
            return Includes();
        }

        public override IQueryable<Personel> GetAll(Expression<Func<Personel, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}
