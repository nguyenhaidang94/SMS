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
        private readonly GenericRepository<Nguoi> _NguoiRepository;

        public HocSinhService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
        }

        /// <summary>
        /// get all hocsinh
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nguoi> GetAllHocSinh()
        {
            //giaovien's persontypeid is 2
            return _NguoiRepository.Entities
                .Where(e => e.PersonTypeId == 2 && e.Active);
        }
        /// <summary>
        /// add ds hoc sinh
        /// </summary>
        /// <param name="dsHocSinh">list Hoc Sinh</param>
        public void AddDsHocSinh(IEnumerable<HocSinh> dsHocSinh)
        {
            foreach (HocSinh hs in dsHocSinh)
            {
                HocSinh hocsinh = new HocSinh();
                hocsinh.NgheNghiepCha = hs.NgheNghiepCha;
                hocsinh.NgheNghiepMe = hs.NgheNghiepMe;
                hocsinh.HoTenCha = hs.HoTenCha;
                hocsinh.HoTenMe = hs.HoTenMe;
                hocsinh.NgaySinh = hs.NgaySinh;
                hocsinh.NoiSinh = hs.NoiSinh;
                hocsinh.HoTen = hs.HoTen;
                hocsinh.GioiTinh = hs.GioiTinh;
                hocsinh.DanToc = hs.DanToc;
                hocsinh.TonGiao = hs.TonGiao;
                hocsinh.DiaChi = hs.DiaChi;
                hocsinh.SDT = hs.SDT;
                hocsinh.CMND = "123456789";
                hocsinh.PersonTypeId = 2;
                _HocSinhRepository.Insert(hocsinh);
            }
        }

       
         //<summary>
         //update danh sach hoc sinh
         //</summary>
         //<param name="dsHocSinh">list Hoc Sinh</param>
        public void UpdateDsHocSinh(IEnumerable<HocSinh> dsHocSinh)
        {
            _HocSinhRepository.Update(dsHocSinh);
        }

        // <summary>
        // delete ds hoc sinh
        // </summary>
        // <param name="dsHocSinh">list Hoc Sinh</param>
        public void DeleteDsHocSinh(IEnumerable<HocSinh> dsHocSinh)
        {
            _HocSinhRepository.FakeDelete(dsHocSinh);
        }

    }
}
