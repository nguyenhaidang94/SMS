using System.Collections.Generic;
using SMS.SERVICE.IService;
using SMS.DATA;
using SMS.CORE.Data;
using SMS.DATA.IRepository;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service namhoc
    /// </summary>
    public class NamHocService: INamHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly INamHocRepository _NamHocRepository;
        
        public NamHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _NamHocRepository = _UnitOfWork.NamHocRepository;
        }

        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        public IEnumerable<NamHoc> GetAllNamHoc()
        {
            return _NamHocRepository.GetAllNamHoc();
        }

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void AddNamHoc(NamHoc entity)
        {
            _NamHocRepository.AddNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void UpdateNamHoc(NamHoc entity)
        {
            _NamHocRepository.UpdateNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void DeleteNamHoc(NamHoc entity)
        {
            _NamHocRepository.FakeDeleteNamHoc(entity);
            _UnitOfWork.SaveChanges();
        }
    }
}
