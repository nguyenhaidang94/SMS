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
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;


        public MonHocService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _MonHocRepository = _UnitOfWork.Repository<MonHoc>();
            _GiaoVienRepository = _UnitOfWork.Repository<GiaoVien>();
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

        /// <summary>
        /// get MonHoc
        /// </summary>
        /// <returns>list MonHoc</returns>
        public IEnumerable<MonHoc> GetAllWithChild()
        {
            var listMonHoc = _MonHocRepository.Entities.Where(m => m.Active == true);
            foreach (MonHoc monHoc in listMonHoc)
            {
                _MonHocRepository.DbContext.Entry(monHoc).Collection(m => m.dsKhoi).Load();
            }
            return listMonHoc;
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
        /// get MonHoc by id
        /// </summary>
        /// <returns>list MonHoc</returns>
        public MonHoc GetByIDWithChild(int id)
        {
            var monHoc = _MonHocRepository.GetEntityById(id);
            _MonHocRepository.DbContext.Entry(monHoc).Collection(m => m.dsKhoi).Load();
            return monHoc;
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

        public List<MonHoc> LayMonHocTheoMaGiaoVien(int id)
        {
            return _GiaoVienRepository.Entities.Where(c => c.PersonId == id && c.Active)
                .SelectMany(e => e.dsGiaoVienMonHoc).Select(d => d.MonHoc).ToList<MonHoc>();
        }

    }
}
