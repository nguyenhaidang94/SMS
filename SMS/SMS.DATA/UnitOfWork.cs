using System;
using SMS.DATA.IRepository;
using SMS.DATA.Repository;
using System.Data.Entity.Validation;

namespace SMS.DATA
{
    /// <summary>
    /// unit of work pattern
    /// </summary>
    public class UnitOfWork
    {
        private readonly SMSContext _db;
        private bool _disposed;
        
        //repository namhoc
        private INamHocRepository _NamHocRepository;
        public INamHocRepository NamHocRepository 
        {
            get { return _NamHocRepository ?? (_NamHocRepository = new NamHocRepository(_db)); }
        }

        //repository hocky
        private IHocKyRepository _HocKyRepository;
        public IHocKyRepository HocKyRepository
        {
            get { return _HocKyRepository ?? (_HocKyRepository = new HocKyRepository(_db)); }
        }

        //repository khenthuong
        private IKhenThuongRepository _KhenThuongRepository;
        public IKhenThuongRepository KhenThuongRepository
        {
            get { return _KhenThuongRepository ?? (_KhenThuongRepository = new KhenThuongRepository(_db)); }
        }

        //repository hocsinh
        private IHocSinhRepository _HocSinhRepository;
        public IHocSinhRepository HocSinhRepository
        {
            get { return _HocSinhRepository ?? (_HocSinhRepository = new HocSinhRepository(_db)); }
        }

        //repository giaovien
        private IGiaoVienRepository _GiaoVienRepository;
        public IGiaoVienRepository GiaoVienRepository
        {
            get { return _GiaoVienRepository ?? (_GiaoVienRepository = new GiaoVienRepository(_db)); }
        }

        //repository tiethoc
        private ITietHocRepository _TietHocRepository;

        public ITietHocRepository TietHocRepository
        {
            get { return _TietHocRepository ?? (_TietHocRepository = new TietHocRepository(_db)); }
        }

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
