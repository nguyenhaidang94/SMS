using System.Collections.Generic;
using SMS.CORE.Data;
using SMS.DATA.Models;
using SMS.SERVICE.IService;
using SMS.DATA;
using System.Linq;

namespace SMS.SERVICE.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class BaoCaoService: IBaoCaoService
    {
        private readonly UnitOfWork _UnitOfWork;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        private readonly GenericRepository<KhoiLop> _KhoiLopRepository;
        private readonly GenericRepository<LopHoc> _LopHocRepository;
        private readonly GenericRepository<HocSinh> _HocSinhRepository;
        private readonly GenericRepository<BangDiemHKMH> _BangDiemRepository;

        public BaoCaoService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _NamHocRepository = _UnitOfWork.Repository<NamHoc>();
            _KhoiLopRepository = _UnitOfWork.Repository<KhoiLop>();
            _LopHocRepository = _UnitOfWork.Repository<LopHoc>();
            _HocSinhRepository = _UnitOfWork.Repository<HocSinh>();
            _BangDiemRepository = _UnitOfWork.Repository<BangDiemHKMH>();
        }

        /// <summary>
        /// report group point
        /// </summary>
        /// <returns>list BaoCaoNhomDiemViewModel</returns>
        public ICollection<BaoCaoNhomDiemViewModel> BaoCaoNhomDiem()
        {
            var dsNamHoc = _NamHocRepository.Entities.Where(e => e.Active);
            var dsKhoi = _KhoiLopRepository.Entities.Where(e => e.Active);
            ICollection<BaoCaoNhomDiemViewModel> dsThongKe = new List<BaoCaoNhomDiemViewModel>();
            foreach (var namhoc in dsNamHoc)
            { 
                foreach (var khoi in dsKhoi)
                {
                    _KhoiLopRepository.DbContext.Entry(khoi).Collection(e => e.dsLopHoc).Load();
                    //lophoc thuoc khoi va namhoc
                    var dsLopHoc = khoi.dsLopHoc.Where(e => e.Active && e.MaNamHoc == namhoc.MaNamHoc);
                    foreach (var lophoc in dsLopHoc)
                    {
                        _LopHocRepository.DbContext.Entry(lophoc).Collection(e => e.dsHocSinh).Load();
                        foreach (var hocsinh in lophoc.dsHocSinh)
                            _HocSinhRepository.DbContext.Entry(hocsinh).Collection(e => e.dsBangDiemHKMH).Load();

                        //bang diem cua hocsinh thuoc lop
                        var dsBangDiem = lophoc.dsHocSinh.SelectMany(e => e.dsBangDiemHKMH);
                        var total = dsBangDiem.Count();
                        BaoCaoNhomDiemViewModel item = new BaoCaoNhomDiemViewModel()
                        {
                            MaNamHoc = namhoc.MaNamHoc,
                            MaKhoi = khoi.MaKhoi,
                            MaLop = lophoc.MaLopHoc,
                            TenLop = lophoc.TenLop 
                        };
                        if (total > 0)
                        {
                            item.good = dsBangDiem.Count(e => e.DiemTB >= 8) * 100 / total;
                            item.prettygood = dsBangDiem.Count(e => e.DiemTB >= 6.5 && e.DiemTB < 8) * 100 / total;
                            item.medium = dsBangDiem.Count(e => e.DiemTB >= 5 && e.DiemTB < 6.5) * 100 / total;
                            item.undermedium = dsBangDiem.Count(e => e.DiemTB < 5) * 100 / total;
                        }
                        dsThongKe.Add(item);
                    }
                }
            }

            return dsThongKe;
        }
    }
}
