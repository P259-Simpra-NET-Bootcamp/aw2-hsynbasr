using Data.Context;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.GenericRepository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly AppDbContext dbContext;
        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = dbContext.Set<Entity>().Find(id);
            dbContext.Set<Entity>().Remove(entity);
        }

        public List<Entity> GetAll()
        {
            return dbContext.Set<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            return dbContext.Set<Entity>().Find(id);
        }

        public void Insert(Entity entity)
        {
            dbContext.Set<Entity>().Add(entity);
        }
        public List<Entity> GetCity(Expression<Func<Entity, bool>> where)
        {
            if (where==null)
            {
                return dbContext.Set<Entity>().ToList();
            }
            else
            {
                
            return dbContext.Set<Entity>().Where(where).ToList();
            }
        }


        public void Update(Entity entity)
        {
            dbContext.Set<Entity>().Update(entity);
        }
    }
}
