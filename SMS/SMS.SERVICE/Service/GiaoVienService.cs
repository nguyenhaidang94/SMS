using SMS.CORE.Data;
using SMS.DATA;
using System.Linq;
using SMS.SERVICE.IService;
using System.Collections.Generic;
using SMS.DATA.Models;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// service giaovien
    /// </summary>
    public class GiaoVienService : IGiaoVienService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;
        private readonly GenericRepository<MonHoc> _MonHocRepository;
        private readonly GenericRepository<Nguoi> _NguoiRepository;
        private readonly GenericRepository<GiaoVienMonHoc> _GiaoVienMonHocRepository;

        public GiaoVienService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienRepository = _UnitOfWork.Repository<GiaoVien>();
            _NguoiRepository = _UnitOfWork.Repository<Nguoi>();
            _MonHocRepository = _UnitOfWork.Repository<MonHoc>();
            _GiaoVienMonHocRepository = _UnitOfWork.Repository<GiaoVienMonHoc>();

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
        public void AddDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien)
        {
            foreach (GiaoVienViewModel gv in dsGiaoVien)
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
                giaovien.PersonId = gv.PersonId;

                giaovien.PersonTypeId = 1;

                giaovienmh.MaMonHoc = gv.MaMonHoc;
                giaovienmh.MaGiaoVien = GetLastPersonId() + 1;

                _GiaoVienRepository.Insert(giaovien);

                _GiaoVienMonHocRepository.Insert(giaovienmh);


            }
        }


        //<summary>
        //update danh sach giao vien
        //</summary>
        //<param name="dsGiaoVein">list Giao Vien</param>
        public void UpdateDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien)
        {
            foreach (GiaoVienViewModel gv in dsGiaoVien)
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
                giaovien.PersonId = gv.PersonId;

                giaovienmh.MaMonHoc = gv.MaMonHoc;
                giaovienmh.MaGiaoVien = gv.PersonId;
                giaovienmh.Id = gv.Id;


                _GiaoVienMonHocRepository.Update(giaovienmh);
                _GiaoVienRepository.Update(giaovien);
            }
        }

        // <summary>
        // delete ds giao vien
        // </summary>
        // <param name="dsGiaoVien">list Giao Vien</param>
        public void DeleteDsGiaoVien(IEnumerable<GiaoVienViewModel> dsGiaoVien)
        {
            foreach (GiaoVienViewModel gv in dsGiaoVien)
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
                giaovien.PersonId = gv.PersonId;

                giaovienmh.MaMonHoc = gv.MaMonHoc;
                giaovienmh.MaGiaoVien = gv.PersonId;
                giaovienmh.Id = gv.Id;


                _GiaoVienMonHocRepository.FakeDelete(giaovienmh);
                _GiaoVienRepository.FakeDelete(giaovien);
            }
        }

        public List<GiaoVien> LayDanhSachGiaoVienTheoMon(int id)
        {
            return _MonHocRepository.Entities.Where(c => c.MaMonHoc == id && c.Active)
                 .SelectMany(e => e.dsGiaoVienMonHoc).Select(d => d.GiaoVien).ToList<GiaoVien>();
        }

        public int GetLastPersonId()
        {
            int count = GetAllGiaoVien().Count();

            return GetAllGiaoVien().ToList()[count - 1].PersonId;
        }

        public IEnumerable<GiaoVienViewModel> KhoiTaoModel()
        {
            return _GiaoVienMonHocRepository.Entities.Where(a => a.Active)
                 .Join(_GiaoVienRepository.Entities.Where(a => a.Active)
                 , a => a.MaGiaoVien
                 , b => b.PersonId
                  , (a, b) => new { a, b })
                  .Join(_MonHocRepository.Entities.Where(a => a.Active)
                  , c => c.a.MaMonHoc
                  , d => d.MaMonHoc
                  , (c, d) => new GiaoVienViewModel()
                  {
                      TonGiao = c.b.TonGiao,
                      DanToc = c.b.DanToc,
                      DiaChi = c.b.DiaChi,
                      HoTen = c.b.HoTen,
                      MaMonHoc = c.a.MaMonHoc,
                      TenMonHoc = d.TenMonHoc,
                      NoiSinh = c.b.NoiSinh,
                      NgaySinh = c.b.NgaySinh,
                      PersonId = c.b.PersonId,
                      PersonTypeId = c.b.PersonTypeId,
                      SDT = c.b.SDT,
                      GioiTinh = c.b.GioiTinh,
                      CMND = c.b.CMND,
                      MaGiaoVien = c.b.MaGiaoVien,
                      Id = c.a.Id
                  }
                 );
        }
    }
}
