using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service HocKyNamHoc
    /// </summary>
    public class HocKyNamHocService : IHocKyNamHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocKyNamHoc> _HocKyNamHocRepository;
        
        public HocKyNamHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocKyNamHocRepository = _UnitOfWork.Repository<HocKyNamHoc>();
        }

        /// <summary>
        /// get HocKyNamHoc
        /// </summary>
        /// <returns>list HocKyNamHoc</returns>
        public IEnumerable<HocKyNamHoc> GetAll()
        {
            //giaovien's persontypeid is 1
            return _HocKyNamHocRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<HocKyNamHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _HocKyNamHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get HocKyNamHoc by id
        /// </summary>
        /// <returns>list HocKyNamHoc</returns>
        public HocKyNamHoc GetByID(int id)
        {
            return _HocKyNamHocRepository.GetEntityById(id);
        }

        /// <summary>
        /// add HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void Insert(HocKyNamHoc entity)
        {
            _HocKyNamHocRepository.Insert(entity);
        }

        /// <summary>
        /// add list HocKyNamHoc
        /// </summary>
        /// <param name="entity">List HocKyNamHoc</param>
        public void Insert(IEnumerable<HocKyNamHoc> entities)
        {
            _HocKyNamHocRepository.Insert(entities);
        }

        /// <summary>
        /// update HocKyNamHoc 
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void Update(HocKyNamHoc entity)
        {
            _HocKyNamHocRepository.Update(entity);
        }

        /// <summary>
        /// update list HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void Update(IEnumerable<HocKyNamHoc> entities)
        {
            _HocKyNamHocRepository.Update(entities);
        }

        /// <summary>
        /// delete HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void Delete(HocKyNamHoc entity)
        {
            _HocKyNamHocRepository.Delete(entity);
        }

        /// <summary>
        /// delete list HocKyNamHoc
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void Delete(IEnumerable<HocKyNamHoc> entities)
        {
            _HocKyNamHocRepository.Delete(entities);
        }

        /// <summary>
        /// set HocKyNamHoc to unactive
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void FakeDelete(HocKyNamHoc entity)
        {
            _HocKyNamHocRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list HocKyNamHoc to unactive
        /// </summary>
        /// <param name="entity">HocKyNamHoc</param>
        public void FakeDelete(IEnumerable<HocKyNamHoc> entities) 
        {
            _HocKyNamHocRepository.FakeDelete(entities);
        }
    }
}
