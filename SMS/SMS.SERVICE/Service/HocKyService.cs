using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service HocKy
    /// </summary>
    public class HocKyService : IHocKyService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocKy> _HocKyRepository;

        public HocKyService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocKyRepository = _UnitOfWork.Repository<HocKy>();
        }

        /// <summary>
        /// get HocKy
        /// </summary>
        /// <returns>list HocKy</returns>
        public IEnumerable<HocKy> GetAll()
        {
            //giaovien's persontypeid is 1
            return _HocKyRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<HocKy> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _HocKyRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get HocKy by id
        /// </summary>
        /// <returns>list HocKy</returns>
        public HocKy GetByID(int id)
        {
            return _HocKyRepository.GetEntityById(id);
        }

        /// <summary>
        /// add HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void Insert(HocKy entity)
        {
            _HocKyRepository.Insert(entity);
        }

        /// <summary>
        /// add list HocKy
        /// </summary>
        /// <param name="entity">List HocKy</param>
        public void Insert(IEnumerable<HocKy> entities)
        {
            _HocKyRepository.Insert(entities);
        }

        /// <summary>
        /// update HocKy 
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void Update(HocKy entity)
        {
            _HocKyRepository.Update(entity);
        }

        /// <summary>
        /// update list HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void Update(IEnumerable<HocKy> entities)
        {
            _HocKyRepository.Update(entities);
        }

        /// <summary>
        /// delete HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void Delete(HocKy entity)
        {
            _HocKyRepository.Delete(entity);
        }

        /// <summary>
        /// delete list HocKy
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void Delete(IEnumerable<HocKy> entities)
        {
            _HocKyRepository.Delete(entities);
        }

        /// <summary>
        /// set HocKy to unactive
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void FakeDelete(HocKy entity)
        {
            _HocKyRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list HocKy to unactive
        /// </summary>
        /// <param name="entity">HocKy</param>
        public void FakeDelete(IEnumerable<HocKy> entities)
        {
            _HocKyRepository.FakeDelete(entities);
        }
    }
}
