using System.Linq.Expressions;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Data.EntityFramework
{
    public class TestRepository:GenericRepository<TestEntity>
    {
        private IQueryable<TestEntity> Includes()
        {
            var models = dbset.AsQueryable();
            return models;
        }
        public override TestEntity Get(int id)
        {
            var model = Includes().FirstOrDefault(x => x.Id == id);
            return model;
        }
        public override TestEntity Get(Expression<Func<TestEntity, bool>> filter)
        {
            var model = Includes().FirstOrDefault(filter);
            return model;
        }
        public override IQueryable<TestEntity> GetAll()
        {
            return Includes();
        }
        public override IQueryable<TestEntity> GetAll(Expression<Func<TestEntity, bool>> filter)
        {
            return Includes().Where(filter);
        }
    }
}
