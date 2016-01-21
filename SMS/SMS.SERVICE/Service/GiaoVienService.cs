using SMS.CORE.Data;
using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using System.Collections.Generic;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service giaovien
    /// </summary>
    public class GiaoVienService: IGiaoVienService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;
        private readonly GenericRepository<MonHoc> _MonHocRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;

        public GiaoVienService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienRepository = _UnitOfWork.Repository<GiaoVien>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
            _MonHocRepository = _UnitOfWork.Repository<MonHoc>();

        }

        /// <summary>
        /// get all giaovien
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GiaoVien> GetAllGiaoVien()
        {
            //giaovien's persontypeid is 1
            return _GiaoVienRepository.Entities
                .Where(e => e.Active);
        }

        /// <summary>
        /// add ds giao vien
        /// </summary>
        /// <param name="dsQDKhenThuong">list qdkhenthuong</param>
        public void AddDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien)
        {
            foreach (GiaoVien gv in dsGiaoVien)
            {
                GiaoVien giaovien = new GiaoVien();
                GiaoVienMonHoc giaovienmh = new GiaoVienMonHoc();
                giaovienmh.MaGiaoVien = gv.MaGiaoVien;
                

                giaovien.NgaySinh = gv.NgaySinh;
                giaovien.NoiSinh = gv.NoiSinh;
                giaovien.HoTen = gv.HoTen;
                giaovien.GioiTinh = gv.GioiTinh;
                giaovien.DanToc = gv.DanToc;
                giaovien.TonGiao = gv.TonGiao;
                giaovien.DiaChi = gv.DiaChi;
                giaovien.SDT = gv.SDT;
                giaovien.CMND = gv.CMND;
               
                giaovien.PersonTypeId = 1;

                _GiaoVienRepository.Insert(giaovien);
            }
        }


        //<summary>
        //update danh sach giao vien
        //</summary>
        //<param name="dsGiaoVein">list Giao Vien</param>
        public void UpdateDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien)
        {
            _GiaoVienRepository.Update(dsGiaoVien);
        }

        // <summary>
        // delete ds giao vien
        // </summary>
        // <param name="dsGiaoVien">list Giao Vien</param>
        public void DeleteDsGiaoVien(IEnumerable<GiaoVien> dsGiaoVien)
        {
            _GiaoVienRepository.FakeDelete(dsGiaoVien);
        }

       public List<GiaoVien> LayDanhSachGiaoVienTheoMon(int id)
        {
           return _MonHocRepository.Entities.Where(c => c.MaMonHoc == id && c.Active)
                .SelectMany(e => e.dsGiaoVienMonHoc).Select(d => d.GiaoVien).ToList<GiaoVien>();
        }
    }
}
