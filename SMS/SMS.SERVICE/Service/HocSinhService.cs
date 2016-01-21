using System.Collections.Generic;
using System.Linq;
using SMS.CORE.Data;
using SMS.DATA;
using SMS.SERVICE.IService;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service hocsinh
    /// </summary>
    public class HocSinhService: IHocSinhService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        private readonly GenericRepository<LopHoc> _LopHocRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
            _LopHocRepository = _UnitOfWork.Repository<LopHoc>();
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
        /// get all SelectHocSinhViewModel
        /// </summary>
        /// <returns>list SelectHocSinhViewModel</returns>
        public IEnumerable<SelectHocSinhViewModel> GetAllSelectHocSinhVM()
        {
            List<SelectHocSinhViewModel> dsHocSinh = new List<SelectHocSinhViewModel>();

            var dsNamHoc = _NamHocRepository.Entities.Where(e => e.Active);
            foreach (var namhoc in dsNamHoc)
            {
                var dsLopHoc = _LopHocRepository.Entities.Where(e => e.Active && e.MaNamHoc == namhoc.MaNamHoc);
                foreach (var lophoc in dsLopHoc)
                {
                    _LopHocRepository.DbContext.Entry(lophoc).Collection(e => e.dsHocSinh).Load();
                    var dshs = lophoc.dsHocSinh
                        .Select(e => new SelectHocSinhViewModel()
                        {
                            MaHocSinh = e.PersonId,
                            MaNamHoc = namhoc.MaNamHoc,
                            MaLop = lophoc.MaLopHoc,
                            HoTen = e.HoTen,
                            NgaySinh = e.NgaySinh,
                            GioiTinh = e.GioiTinh,
                            Checked = false
                        });
                    dsHocSinh.AddRange(dshs);
                }
            }

            return dsHocSinh;
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
            entity.PersonId = 2;
            _HocSinhRepository.Insert(entity);
        }

        /// <summary>
        /// add list HocSinh
        /// </summary>
        /// <param name="entity">List HocSinh</param>
        public void Insert(IEnumerable<HocSinh> entities)
        {
            foreach (HocSinh hs in entities)
            {
                hs.PersonTypeId = 2;
            }
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
