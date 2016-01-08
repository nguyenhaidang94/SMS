using System.Collections.Generic;
using System.Linq;
using SMS.SERVICE.IService;
using SMS.DATA;
using SMS.CORE.Data;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service namhoc
    /// </summary>
    public class NamHocService: INamHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        
        public NamHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
        }

        /// <summary>
        /// get namhoc
        /// </summary>
        /// <returns>list namhoc</returns>
        public IEnumerable<NamHoc> GetAllNamHoc()
        {
            return _NamHocRepository.Entities.ToList();
        }

        /// <summary>
        /// add namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void AddNamHoc(NamHoc entity)
        {
            _NamHocRepository.Insert(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// update namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void UpdateNamHoc(NamHoc entity)
        {
            _NamHocRepository.Update(entity);
            _UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// delete namhoc
        /// </summary>
        /// <param name="entity">namhoc</param>
        public void DeleteNamHoc(NamHoc entity)
        {
            _NamHocRepository.FakeDelete(entity);
            _UnitOfWork.SaveChanges();
        }
    }
}
