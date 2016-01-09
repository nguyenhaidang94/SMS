using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service NamHoc
    /// </summary>
    public class NamHocService : INamHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<NamHoc> _NamHocRepository;

        public NamHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
        }

        /// <summary>
        /// get NamHoc
        /// </summary>
        /// <returns>list NamHoc</returns>
        public IEnumerable<NamHoc> GetAll()
        {
            //giaovien's persontypeid is 1
            return _NamHocRepository.Entities.Where(m => m.Active == true);
        }

        public IEnumerable<NamHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _NamHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get NamHoc by id
        /// </summary>
        /// <returns>list NamHoc</returns>
        public NamHoc GetByID(int id)
        {
            return _NamHocRepository.GetEntityById(id);
        }

        /// <summary>
        /// add NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void Insert(NamHoc entity)
        {
            _NamHocRepository.Insert(entity);
        }

        /// <summary>
        /// add list NamHoc
        /// </summary>
        /// <param name="entity">List NamHoc</param>
        public void Insert(IEnumerable<NamHoc> entities)
        {
            _NamHocRepository.Insert(entities);
        }

        /// <summary>
        /// update NamHoc 
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void Update(NamHoc entity)
        {
            _NamHocRepository.Update(entity);
        }

        /// <summary>
        /// update list NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void Update(IEnumerable<NamHoc> entities)
        {
            _NamHocRepository.Update(entities);
        }

        /// <summary>
        /// delete NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void Delete(NamHoc entity)
        {
            _NamHocRepository.Delete(entity);
        }

        /// <summary>
        /// delete list NamHoc
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void Delete(IEnumerable<NamHoc> entities)
        {
            _NamHocRepository.Delete(entities);
        }

        /// <summary>
        /// set NamHoc to unactive
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void FakeDelete(NamHoc entity)
        {
            _NamHocRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list NamHoc to unactive
        /// </summary>
        /// <param name="entity">NamHoc</param>
        public void FakeDelete(IEnumerable<NamHoc> entities)
        {
            _NamHocRepository.FakeDelete(entities);
        }
    }
}
