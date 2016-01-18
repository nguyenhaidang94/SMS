using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service hocsinh
    /// </summary>
    public class HocSinhService: IHocSinhService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
        }

        /// <summary>
        /// get HocSinh
        /// </summary>
        /// <returns>list HocSinh</returns>
        public IEnumerable<HocSinh> GetAll()
        {
            //giaovien's persontypeid is 1
            return _HocSinhRepository.Entities.Where(m => m.Active == true);
        }

        /// <summary>
        /// get HocSinh
        /// </summary>
        /// <returns>list HocSinh</returns>
        public IEnumerable<HocSinh> GetAllWithChild()
        {
            var listHocSinh = _HocSinhRepository.Entities.Where(m => m.Active == true);
            foreach (HocSinh hs in listHocSinh)
            {
                _HocSinhRepository.DbContext.Entry(hs).Collection(m => m.dsLopHoc).Load();
            }
            return listHocSinh;
        }

        public IEnumerable<HocSinh> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _HocSinhRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get HocSinh by id
        /// </summary>
        /// <returns>list HocSinh</returns>
        public HocSinh GetByID(int id)
        {
            return _HocSinhRepository.GetEntityById(id);
        }

        /// <summary>
        /// get HocSinh by id
        /// </summary>
        /// <returns>list HocSinh</returns>
        public HocSinh GetByIDWithChild(int id)
        {
            var hocSinh = _HocSinhRepository.GetEntityById(id);
            _HocSinhRepository.DbContext.Entry(hocSinh).Collection(m => m.dsLopHoc).Load();
            return hocSinh;
        }

        /// <summary>
        /// add HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void Insert(HocSinh entity)
        {
            _HocSinhRepository.Insert(entity);
        }

        /// <summary>
        /// add list HocSinh
        /// </summary>
        /// <param name="entity">List HocSinh</param>
        public void Insert(IEnumerable<HocSinh> entities)
        {
            _HocSinhRepository.Insert(entities);
        }

        /// <summary>
        /// update HocSinh 
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void Update(HocSinh entity)
        {
            _HocSinhRepository.Update(entity);
        }

        /// <summary>
        /// update list HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void Update(IEnumerable<HocSinh> entities)
        {
            _HocSinhRepository.Update(entities);
        }

        /// <summary>
        /// delete HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void Delete(HocSinh entity)
        {
            _HocSinhRepository.Delete(entity);
        }

        /// <summary>
        /// delete list HocSinh
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void Delete(IEnumerable<HocSinh> entities)
        {
            _HocSinhRepository.Delete(entities);
        }

        /// <summary>
        /// set HocSinh to unactive
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void FakeDelete(HocSinh entity)
        {
            _HocSinhRepository.FakeDelete(entity);
        }

        /// <summary>
        ///  set list HocSinh to unactive
        /// </summary>
        /// <param name="entity">HocSinh</param>
        public void FakeDelete(IEnumerable<HocSinh> entities)
        {
            _HocSinhRepository.FakeDelete(entities);
        }
    }
}
