using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service MonHocKhoi
    /// </summary>
    public class MonHocKhoiService : IMonHocKhoiService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<MonHocKhoi> _MonHocKhoiRepository;

        public MonHocKhoiService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _MonHocKhoiRepository = _UnitOfWork.Repository<MonHocKhoi>();
        }

        /// <summary>
        /// get MonHocKhoi
        /// </summary>
        /// <returns>list MonHocKhoi</returns>
        public IEnumerable<MonHocKhoi> GetAll()
        {
            //giaovien's persontypeid is 1
            return _MonHocKhoiRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<MonHocKhoi> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _MonHocKhoiRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get MonHocKhoi by id
        /// </summary>
        /// <returns>list MonHocKhoi</returns>
        public MonHocKhoi GetByID(int id)
        {
            return _MonHocKhoiRepository.GetEntityById(id);
        }

        /// <summary>
        /// add MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void Insert(MonHocKhoi entity)
        {
            _MonHocKhoiRepository.Insert(entity);
        }

        /// <summary>
        /// add list MonHocKhoi
        /// </summary>
        /// <param name="entity">List MonHocKhoi</param>
        public void Insert(IEnumerable<MonHocKhoi> entities)
        {
            _MonHocKhoiRepository.Insert(entities);
        }

        /// <summary>
        /// update MonHocKhoi 
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void Update(MonHocKhoi entity)
        {
            _MonHocKhoiRepository.Update(entity);
        }

        /// <summary>
        /// update list MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void Update(IEnumerable<MonHocKhoi> entities)
        {
            _MonHocKhoiRepository.Update(entities);
        }

        /// <summary>
        /// delete MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void Delete(MonHocKhoi entity)
        {
            _MonHocKhoiRepository.Delete(entity);
        }

        /// <summary>
        /// delete list MonHocKhoi
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void Delete(IEnumerable<MonHocKhoi> entities)
        {
            _MonHocKhoiRepository.Delete(entities);
        }

        /// <summary>
        /// set MonHocKhoi to unactive
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void FakeDelete(MonHocKhoi entity)
        {
            _MonHocKhoiRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list MonHocKhoi to unactive
        /// </summary>
        /// <param name="entity">MonHocKhoi</param>
        public void FakeDelete(IEnumerable<MonHocKhoi> entities)
        {
            _MonHocKhoiRepository.FakeDelete(entities);
        }
    }
}
