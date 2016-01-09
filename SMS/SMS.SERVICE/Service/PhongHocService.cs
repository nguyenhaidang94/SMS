using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service PhongHoc
    /// </summary>
    public class PhongHocService : IPhongHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<PhongHoc> _PhongHocRepository;

        public PhongHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _PhongHocRepository = _UnitOfWork.Repository<PhongHoc>();
        }

        /// <summary>
        /// get PhongHoc
        /// </summary>
        /// <returns>list PhongHoc</returns>
        public IEnumerable<PhongHoc> GetAll()
        {
            //giaovien's persontypeid is 1
            return _PhongHocRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<PhongHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _PhongHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get PhongHoc by id
        /// </summary>
        /// <returns>list PhongHoc</returns>
        public PhongHoc GetByID(int id)
        {
            return _PhongHocRepository.GetEntityById(id);
        }

        /// <summary>
        /// add PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void Insert(PhongHoc entity)
        {
            _PhongHocRepository.Insert(entity);
        }

        /// <summary>
        /// add list PhongHoc
        /// </summary>
        /// <param name="entity">List PhongHoc</param>
        public void Insert(IEnumerable<PhongHoc> entities)
        {
            _PhongHocRepository.Insert(entities);
        }

        /// <summary>
        /// update PhongHoc 
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void Update(PhongHoc entity)
        {
            _PhongHocRepository.Update(entity);
        }

        /// <summary>
        /// update list PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void Update(IEnumerable<PhongHoc> entities)
        {
            _PhongHocRepository.Update(entities);
        }

        /// <summary>
        /// delete PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void Delete(PhongHoc entity)
        {
            _PhongHocRepository.Delete(entity);
        }

        /// <summary>
        /// delete list PhongHoc
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void Delete(IEnumerable<PhongHoc> entities)
        {
            _PhongHocRepository.Delete(entities);
        }

        /// <summary>
        /// set PhongHoc to unactive
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void FakeDelete(PhongHoc entity)
        {
            _PhongHocRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list PhongHoc to unactive
        /// </summary>
        /// <param name="entity">PhongHoc</param>
        public void FakeDelete(IEnumerable<PhongHoc> entities)
        {
            _PhongHocRepository.FakeDelete(entities);
        }
    }
}
