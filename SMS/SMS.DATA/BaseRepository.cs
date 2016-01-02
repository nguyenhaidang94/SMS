using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.CORE;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SMS.DATA
{
    /// <summary>
    /// base repository
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public partial class BaseRepository<T> where T: BaseEntity
    {
        protected readonly SMSContext _db;
        private IDbSet<T> _Entities;

        /// <summary>
        /// get all entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (this._Entities == null)
                    this._Entities = _db.Set<T>();
                return this._Entities;
            }
        }

        /// <summary>
        /// get a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        public BaseRepository()
        { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="dbContext">dbcontext</param>
        public BaseRepository(SMSContext dbContext)
        {
            this._db = dbContext;
        }

        /// <summary>
        /// Get entity by ids
        /// </summary>
        /// <param name="ids">entity primary key</param>
        /// <returns>entity</returns>
        public virtual T GetEntityById(params object[] ids)
        {
            T entity;
            try
            {
                this._db.Configuration.AutoDetectChangesEnabled = false;
                entity = this._Entities.Find(ids);
            }
            catch 
            {
                throw;            
            }
            finally
            {
                this._db.Configuration.AutoDetectChangesEnabled = true;
            }
            return entity;
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity is null");

                this.Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity is null");

                this._db.Entry<T>(entity).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity is null");

                this.Entities.Remove(entity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// delete entity by ids
        /// </summary>
        /// <param name="ids">entity's primary key</param>
        public virtual void DeleteById(params object[] ids)
        {
            try
            {
                var entity = GetEntityById(ids);
                if (entity != null)
                    Delete(entity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// InActive entity
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void FakeDelete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity is null");

                entity.Active = false;
                this._db.Entry<T>(entity).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }
        
        /// <summary>
        /// InActive entity
        /// </summary>
        /// <param name="ids">entity's primary key</param>
        public void FakeDeleteById(params object[] ids)
        {
            try
            {
                var entity = GetEntityById(ids);
                if (entity != null)
                    FakeDelete(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
