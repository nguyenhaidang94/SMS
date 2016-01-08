using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using SMS.CORE;

namespace SMS.DATA
{
    /// <summary>
    /// unit of work pattern
    /// </summary>
    public class UnitOfWork
    {
        private readonly SMSContext _db;
        private bool _disposed;
        private Dictionary<string, object> Repositories;

        public UnitOfWork()
        {
            _db = new SMSContext();
        }

        public UnitOfWork(SMSContext context)
        {
            _db = context;
        }

        /// <summary>
        /// save change
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        /// <summary>
        /// manage all repositories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (Repositories == null)
            {
                Repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!Repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _db);
                Repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)Repositories[type];
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// dispose context
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
