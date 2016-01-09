using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service LopHoc
    /// </summary>
    public class LopHocService : ILopHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<LopHoc> _LopHocRepository;
        
        public LopHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _LopHocRepository = _UnitOfWork.Repository<LopHoc>();
        }

        /// <summary>
        /// get LopHoc
        /// </summary>
        /// <returns>list LopHoc</returns>
        public IEnumerable<LopHoc> GetAll()
        {
            //giaovien's persontypeid is 1
            return _LopHocRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<LopHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _LopHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get LopHoc by id
        /// </summary>
        /// <returns>list LopHoc</returns>
        public LopHoc GetByID(int id)
        {
            return _LopHocRepository.GetEntityById(id);
        }

        /// <summary>
        /// add LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void Insert(LopHoc entity)
        {
            _LopHocRepository.Insert(entity);
        }

        /// <summary>
        /// add list LopHoc
        /// </summary>
        /// <param name="entity">List LopHoc</param>
        public void Insert(IEnumerable<LopHoc> entities)
        {
            _LopHocRepository.Insert(entities);
        }

        /// <summary>
        /// update LopHoc 
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void Update(LopHoc entity)
        {
            _LopHocRepository.Update(entity);
        }

        /// <summary>
        /// update list LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void Update(IEnumerable<LopHoc> entities)
        {
            _LopHocRepository.Update(entities);
        }

        /// <summary>
        /// delete LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void Delete(LopHoc entity)
        {
            _LopHocRepository.Delete(entity);
        }

        /// <summary>
        /// delete list LopHoc
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void Delete(IEnumerable<LopHoc> entities)
        {
            _LopHocRepository.Delete(entities);
        }

        /// <summary>
        /// set LopHoc to unactive
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void FakeDelete(LopHoc entity)
        {
            _LopHocRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list LopHoc to unactive
        /// </summary>
        /// <param name="entity">LopHoc</param>
        public void FakeDelete(IEnumerable<LopHoc> entities) 
        {
            _LopHocRepository.FakeDelete(entities);
        }
    }
}
