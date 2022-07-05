using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore6.Data.Repository
{
    public interface IRepository<Entity>
    {
        int UserID { get; set; }

        IQueryable<Entity> Get();
        Entity Get(int id);
        Entity FirstOrDefault(Expression<Func<Entity, bool>> predicate);
        Entity FirstOrDefault(int id);
        Entity FirstOrDefault();
        IQueryable<Entity> GetWithDeleted();
        bool Any(Expression<Func<Entity, bool>> predicate);
        IQueryable<Entity> Get(Expression<Func<Entity, bool>> predicate);
        Entity Add(Entity entity);

        int GetLastID();
        void Update(Entity entity);
        void SaveIncluded(Entity entity, params string[] properties);
        void SaveExcluded(Entity entity, params string[] properties);
        void Delete(int id);
        Entity First(int id);
        Entity First(Expression<Func<Entity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Entity, bool>> predicate);
        Task<Entity> FirstOrDefaultAsync(Expression<Func<Entity, bool>> predicate);
        Task<Entity> LastOrDefaultAsync(Expression<Func<Entity, bool>> predicate);
        bool IsDeleted(int id);
    }
}

