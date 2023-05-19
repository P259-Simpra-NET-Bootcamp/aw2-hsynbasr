
using System.Linq.Expressions;


namespace Data.Repository.GenericRepository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Entity GetById(int id);
        void Insert(Entity entity);
        void Update(Entity entity);
        void DeleteById(int id);
        void Delete(Entity entity);
        public List<Entity> GetCity(Expression<Func<Entity, bool>> where);
        List<Entity> GetAll();
    }
}
