
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCore6.Data.UnitofWork;
using DotNetCore6.Models;

namespace DotNetCore6.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        public readonly DbSet<T> dbSet;
        protected readonly DbContext context;

        protected string[] defaultExcludedEditProperties = new string[]
        {nameof(BaseModel.CreatedDate),nameof(BaseModel.CreatedBy) ,nameof(BaseModel.IsDeleted) };
        protected string[] defaultExcludedDeleteProperties = new string[]
        {nameof(BaseModel.CreatedDate),nameof(BaseModel.CreatedBy) };

        private readonly IUnitOfWork _unitOfWork;

        public int UserID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.context.Set<T>();
        }
        public T Add(T entity)
        {
            entity.CreatedBy = _unitOfWork.UserID;
            entity.CreatedDate = DateTime.Now;
            _unitOfWork.context.Set<T>().Add(entity);

            return entity;
        }
        public bool IsDeleted(int id)
        {
            T entity = new T();
            entity.ID = id;
            return GetWithDeleted().FirstOrDefault(e => e.ID == entity.ID)?.IsDeleted ?? true;
        }
       
        public void Delete(int id)
        {
            T entity = new T();
            entity.ID = id;
            entity.IsDeleted = true;
            SaveIncluded(entity, nameof(entity.IsDeleted), nameof(entity.UpdatedBy), nameof(entity.UpdatedDate));

        }



        public IQueryable<T> Get()
        {
            return _unitOfWork.context.Set<T>().Where(entity => !entity.IsDeleted);//.AsNoTracking();
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate);
        }

        public T Get(int id)
        {
            return Get().FirstOrDefault(item => item.ID == id);
        }
        public IQueryable<T> GetWithDeleted()
        {
            return _unitOfWork.context.Set<T>();
        }
        public bool ExistsLocal(T entity)
        {
            return this._unitOfWork.context.Set<T>().Local.Any(e => e == entity);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate).FirstOrDefault();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get().Where(predicate).FirstOrDefaultAsync();
        }

        public T FirstOrDefault(int id)
        {
            return FirstOrDefault(item => item.ID == id);
        }
        public T First(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate).First();
        }
        public T First(int id)
        {
            return First(item => item.ID == id);
        }

        public T FirstOrDefault()
        {
            return Get().FirstOrDefault();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Get().Any(predicate);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get().AnyAsync(predicate);
        }

        public void Update(T entity)
        {
            if (entity.ID == 0)
                return;
           
            SaveExcluded(entity, nameof(BaseModel.ID), nameof(BaseModel.CreatedBy), nameof(BaseModel.CreatedDate), nameof(BaseModel.IsDeleted));
        }
        private void RemoveIfAttachedToContext(T entity)
        {
            var local = _unitOfWork.context.Set<T>()
 .Local
 .FirstOrDefault(entry => entry.ID.Equals(entity.ID));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _unitOfWork.context.Entry(local).State = EntityState.Detached;
            }
        }
        public virtual void SaveIncluded(T entity, params string[] properties)
        {
            //if (entity.ID == 0)
            //    return;
            RemoveIfAttachedToContext(entity);

            var entry = _unitOfWork.context.Entry(entity);
            foreach (var prop in entry.Properties)
            {
                if (properties.Contains(prop.Metadata.Name))
                    prop.IsModified = true;
                else
                    prop.IsModified = false;
            }
            entity.UpdatedBy = _unitOfWork.UserID;
            entity.UpdatedDate = DateTime.Now;
        }
        public virtual void SaveExcluded(T entity, params string[] properties)
        {
            if (entity.ID == 0)
                return;
            List<string> excludedProperties = properties.ToList();
            excludedProperties.Add(nameof(BaseModel.ID));
            excludedProperties.Add(nameof(BaseModel.CreatedBy));
            excludedProperties.Add(nameof(BaseModel.CreatedDate));
            excludedProperties.Add(nameof(BaseModel.IsDeleted));

            RemoveIfAttachedToContext(entity);
            entity.UpdatedBy = _unitOfWork.UserID;
            entity.UpdatedDate = DateTime.Now;
            var entry = _unitOfWork.context.Entry(entity);
            foreach (var prop in entry.Properties)
            {
                if (excludedProperties.Contains(prop.Metadata.Name))
                    prop.IsModified = false;
                else
                    prop.IsModified = true;
            }
        }

        public int GetLastID()
        {
            return GetWithDeleted().OrderByDescending(item => item.ID).FirstOrDefault()?.ID ?? 0;
        }

        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get(predicate).OrderByDescending(x => x.ID).FirstOrDefaultAsync();
        }
    }

}
