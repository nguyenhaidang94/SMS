using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service LopHoc
    /// </summary>
    public class LopHocService : ILopHocService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<LopHoc> _LopHocRepository;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        
        public LopHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _LopHocRepository = _UnitOfWork.Repository<LopHoc>();
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
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

        /// <summary>
        /// get LopHoc
        /// </summary>
        /// <returns>list LopHoc</returns>
        public IEnumerable<LopHoc> GetAllWithChild()
        {
            var listLopHoc = _LopHocRepository.Entities.Where(m => m.Active == true);
            foreach (LopHoc lop in listLopHoc)
            {
                _LopHocRepository.DbContext.Entry(lop).Collection(m => m.dsHocSinh).Load();
            }
            return listLopHoc;
        }

        public IEnumerable<LopHoc> GetAllInactive()
        {
            //giaovien's persontypeid is 1
            return _LopHocRepository.Entities.Where(m => m.Active == false);
        }

        /// <summary>
        /// get all lophocviewmodel
        /// </summary>
        /// <returns>list lophocviewmodel</returns>
        public IEnumerable<LopHocViewModel> GetAllLopHocViewModel()
        {
            return _LopHocRepository.Entities.Where(e => e.Active)
                .Select(e => new LopHocViewModel() 
                { 
                    MaNamHoc = e.MaNamHoc,
                    MaLopHoc = e.MaLopHoc,
                    TenLopHoc = e.TenLop
                });
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
        /// get LopHoc by id
        /// </summary>
        /// <returns>list LopHoc with dsHocSinh</returns>
        public LopHoc GetByIDWithChild(int id)
        {
            var lopHoc = _LopHocRepository.GetEntityById(id);
            _LopHocRepository.DbContext.Entry(lopHoc).Collection(m => m.dsHocSinh).Load();
            return lopHoc;
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
