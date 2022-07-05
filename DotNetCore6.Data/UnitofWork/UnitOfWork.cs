
using DotNetCore6.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DotNetCore6.Helpers;
using DotNetCore6.Models.Enums;

namespace DotNetCore6.Data.UnitofWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool _disposed;

        public Entities context { get; }
        public int UserID { set; get; }
        public Language Language { set; get; } = Language.Arabic;
        public UnitOfWork(Entities context)
        {
            this.context = context;
            BeginTransaction();
        }
        public UnitOfWork()
        {
            context = new Entities();
            //BeginTransaction();
        }
        public bool Save(bool isPartial = false)
        {
            try
            {
                context.SaveChanges();
                if (!isPartial)
                    CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }



        }
        public async Task<bool> SaveAsync(bool isPartial = false)
        {
            try
            {
                context.SaveChangesAsync();
                if (!isPartial)
                    CommitTransaction();
                return true;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw ex;
            }



        }
       
        public void Dispose()
        {
            if (context.Database.CurrentTransaction != null)
                context.Database.CloseConnection();
            context.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (context.Database.CurrentTransaction != null)
                        context.Database.CloseConnection();
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void BeginTransaction()
        {
            context.Database.CloseConnection();

            if (context.Database.CurrentTransaction == null)
                context.Database.BeginTransaction();
        }

        private void RollbackTransaction()
        {
            if (context.Database.CurrentTransaction != null)
                context.Database.RollbackTransaction();
        }
        public void Rollback()
        {
            RollbackTransaction();
        }

        private void CommitTransaction()
        {
            if (context.Database.CurrentTransaction != null)
                context.Database.CommitTransaction();
        }

        public bool SavePartial()
        {
            return Save(true);
        }
        public async Task<bool> SavePartialAsync()
        {
            return await SaveAsync(true);
        }
    }
}
