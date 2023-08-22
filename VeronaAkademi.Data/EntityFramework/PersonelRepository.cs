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
                .Include(x=>x.Departman)
                .Include(x=>x.PersonelTip)
                .AsQueryable();
            return models;
        }
        public override Personel Get(int id)
        {
            var model = Includes().FirstOrDefault(x => x.PersonelId == id);
            return model;
        }
        public override Personel Get(Expression<Func<Personel, bool>> filter)
        {
            var model = Includes().FirstOrDefault(filter);
            return model;
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
