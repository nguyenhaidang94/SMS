using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service MonHoc
    /// </summary>
    public class MonHocService : IMonHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<MonHoc> _MonHocRepository;

        public MonHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _MonHocRepository = _UnitOfWork.Repository<MonHoc>();
        }

        /// <summary>
        /// get MonHoc
        /// </summary>
        /// <returns>list MonHoc</returns>
        public IEnumerable<MonHoc> GetAll()
        {
            //giaovien's persontypeid is 1
            return _MonHocRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<MonHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _MonHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get MonHoc by id
        /// </summary>
        /// <returns>list MonHoc</returns>
        public MonHoc GetByID(int id)
        {
            return _MonHocRepository.GetEntityById(id);
        }

        /// <summary>
        /// add MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void Insert(MonHoc entity)
        {
            _MonHocRepository.Insert(entity);
        }

        /// <summary>
        /// add list MonHoc
        /// </summary>
        /// <param name="entity">List MonHoc</param>
        public void Insert(IEnumerable<MonHoc> entities)
        {
            _MonHocRepository.Insert(entities);
        }

        /// <summary>
        /// update MonHoc 
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void Update(MonHoc entity)
        {
            _MonHocRepository.Update(entity);
        }

        /// <summary>
        /// update list MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void Update(IEnumerable<MonHoc> entities)
        {
            _MonHocRepository.Update(entities);
        }

        /// <summary>
        /// delete MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void Delete(MonHoc entity)
        {
            _MonHocRepository.Delete(entity);
        }

        /// <summary>
        /// delete list MonHoc
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void Delete(IEnumerable<MonHoc> entities)
        {
            _MonHocRepository.Delete(entities);
        }

        /// <summary>
        /// set MonHoc to unactive
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void FakeDelete(MonHoc entity)
        {
            _MonHocRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list MonHoc to unactive
        /// </summary>
        /// <param name="entity">MonHoc</param>
        public void FakeDelete(IEnumerable<MonHoc> entities)
        {
            _MonHocRepository.FakeDelete(entities);
        }
    }
}
