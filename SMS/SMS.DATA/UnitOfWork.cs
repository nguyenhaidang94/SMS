using SMS.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.DATA.IRepository;
using SMS.DATA.Repository;
using System.Data.Entity.Validation;

namespace SMS.DATA
{
    /// <summary>
    /// unit of work pattern
    /// </summary>
    public partial class UnitOfWork
    {
        private readonly SMSContext _db;
        private bool disposed;
        private INamHocRepository _NamHocRepository;
        public INamHocRepository NamHocRepository 
        {
            get 
            {
                if (_NamHocRepository == null)
                    _NamHocRepository = new NamHocRepository(_db);
                return _NamHocRepository;
            }
        }

        private IHocKyRepository _HocKyRepository;
        public IHocKyRepository HocKyRepository
        {
            get
            {
                if (_HocKyRepository == null)
                    _HocKyRepository = new HocKyRepository(_db);
                return _HocKyRepository;
            }
        }

        public UnitOfWork()
        {
            _db = new SMSContext();
        }

        public UnitOfWork(SMSContext context)
        {
            this._db = context;
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
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }
    }
}
