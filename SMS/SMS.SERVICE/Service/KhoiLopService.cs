using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service KhoiLop
    /// </summary>
    public class KhoiLopService : IKhoiLopService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<KhoiLop> _KhoiLopRepository;

        public KhoiLopService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _KhoiLopRepository = _UnitOfWork.Repository<KhoiLop>();
        }

        /// <summary>
        /// get KhoiLop
        /// </summary>
        /// <returns>list KhoiLop</returns>
        public IEnumerable<KhoiLop> GetAll()
        {
            //giaovien's persontypeid is 1
            return _KhoiLopRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<KhoiLop> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _KhoiLopRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get KhoiLop by id
        /// </summary>
        /// <returns>list KhoiLop</returns>
        public KhoiLop GetByID(int id)
        {
            return _KhoiLopRepository.GetEntityById(id);
        }

        /// <summary>
        /// add KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void Insert(KhoiLop entity)
        {
            if (!_KhoiLopRepository.Table.Any(m => m.TenKhoi == entity.TenKhoi))
            {
                _KhoiLopRepository.Insert(entity);
            }
        }

        /// <summary>
        /// add list KhoiLop
        /// </summary>
        /// <param name="entity">List KhoiLop</param>
        public void Insert(IEnumerable<KhoiLop> entities)
        {
            _KhoiLopRepository.Insert(entities);
        }

        /// <summary>
        /// update KhoiLop 
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void Update(KhoiLop entity)
        {
            _KhoiLopRepository.Update(entity);
        }

        /// <summary>
        /// update list KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void Update(IEnumerable<KhoiLop> entities)
        {
            _KhoiLopRepository.Update(entities);
        }

        /// <summary>
        /// delete KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void Delete(KhoiLop entity)
        {
            _KhoiLopRepository.Delete(entity);
        }

        /// <summary>
        /// delete list KhoiLop
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void Delete(IEnumerable<KhoiLop> entities)
        {
            _KhoiLopRepository.Delete(entities);
        }

        /// <summary>
        /// set KhoiLop to unactive
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void FakeDelete(KhoiLop entity)
        {
            _KhoiLopRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list KhoiLop to unactive
        /// </summary>
        /// <param name="entity">KhoiLop</param>
        public void FakeDelete(IEnumerable<KhoiLop> entities)
        {
            _KhoiLopRepository.FakeDelete(entities);
        }
    }
}
