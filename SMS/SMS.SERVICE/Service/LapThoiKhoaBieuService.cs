using SMS.CORE.Data;
using SMS.DATA;
using SMS.DATA.Models;
using SMS.SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.SERVICE.Service
{
    public class LapThoiKhoaBieuService : ILapThoiKhoaBieuService
    {
        private const String KHOI6 = "1";
        private const String KHOI7 = "2";
        private const String KHOI8 = "3";
        private const String KHOI9 = "4";

        private const int _SOTIETHOCTRONGTUAN = 30;

        private readonly GenericRepository<LichGiangDay> _TKBRepository;
        private readonly GenericRepository<CT_LichGiangDay> _CTLichGiangDayRepository;
        private readonly GenericRepository<GiaoVien> _GiaoVienRepository;
        private readonly GenericRepository<GiaoVienMonHoc> _GiaoVienMonHocRepository;
        private readonly GenericRepository<LopHoc> _LopHocRepository;
        private readonly GenericRepository<MonHoc> _MonHocRepository;
        private readonly GenericRepository<NamHoc> _NamHocRepository;
        private readonly GenericRepository<HocKy> _HocKyRepository;
        private readonly GenericRepository<PhongHoc> _PhongHocRepository;


        private readonly UnitOfWork _UnitOfWork;

        private GiaoVienService _GiaoVienService;
        private MonHocService _MonHocService;
        private List<GiaoVien> _ListGiaoVien; // danh sách giáo viên của trường

        private GiaoVien[][] _ListGiaoVienTheoMon;
        private List<MonHoc> _ListMonHoc; // danh sách môn học
       
        private List<LopHoc> _ListLop; // danh sách lớp lập lịch
        private List<ChuongTrinhHocService> _ListChuongTrinhHoc; // danh sách các tiết học từng khối trong 1 tuần

        private LichGiangDay[][] _QuanTheBanDau; // thời khóa biểu

        public LapThoiKhoaBieuService(UnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
            _GiaoVienService = new GiaoVienService(_UnitOfWork);
            _TKBRepository = unitOfWork.Repository<LichGiangDay>();
            _CTLichGiangDayRepository = unitOfWork.Repository<CT_LichGiangDay>();
            _GiaoVienRepository = unitOfWork.Repository<GiaoVien>();
            _GiaoVienMonHocRepository = unitOfWork.Repository<GiaoVienMonHoc>();
            _MonHocRepository = unitOfWork.Repository<MonHoc>();
            _LopHocRepository = unitOfWork.Repository<LopHoc>();
            _NamHocRepository = unitOfWork.Repository<NamHoc>();
            _HocKyRepository = unitOfWork.Repository<HocKy>();
            _PhongHocRepository = unitOfWork.Repository<PhongHoc>();
        }

        public IEnumerable<LichGiangDay> GetAll()
        {
            return _TKBRepository.Entities
               .Where(e => e.Active);
        }

        public LapThoiKhoaBieuService(List<GiaoVien> ListGiaoVien, List<MonHoc> ListMonHoc, List<LopHoc> ListLop, List<LichGiangDay> ListGiangDay, UnitOfWork unitOfWork)
        {
            _GiaoVienService = new GiaoVienService(unitOfWork);
            _MonHocService = new MonHocService(unitOfWork);
            _TKBRepository = unitOfWork.Repository<LichGiangDay>();

            this._ListGiaoVien = ListGiaoVien;
            this._ListLop = ListLop;
            this._ListMonHoc = ListMonHoc;
            _ListGiaoVienTheoMon = TaoDanhSachGiaoVienTheoMon();
     
            // khoi tao ctr hoc cho khoi
            _ListChuongTrinhHoc = new List<ChuongTrinhHocService>();
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_6, _ListMonHoc));
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_7, _ListMonHoc));
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_8, _ListMonHoc));
            _ListChuongTrinhHoc.Add(TinhSoTietHocTrongTuan(KHOI.KHOI_9, _ListMonHoc));
        }

         /// <summary>
         /// tính số tiết học trong tuần của mỗi khối
         /// </summary>
         public ChuongTrinhHocService TinhSoTietHocTrongTuan(KHOI Khoi, List<MonHoc> ListGiangDay)
         {
             List<MonHoc> SoTietHocTrongTuan = new List<MonHoc>();
             for (int i = 0; i < _ListMonHoc.Count; i++) // duyệt danh sach môn học
             {
                 // tạo các tiết học theo từng khối cụ thể
                 if (Khoi == KHOI.KHOI_6)
                 {
                     for (int k = 0; k < _ListMonHoc[i].SoTiet; k++)
                     {
                         SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                     }
                 }
                 else if (Khoi == KHOI.KHOI_7)
                 {
                     for (int k = 0; k < _ListMonHoc[i].SoTiet; k++)
                     {
                         SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                     }
                 }
                 else if (Khoi == KHOI.KHOI_8)
                 {
                     for (int k = 0; k < _ListMonHoc[i].SoTiet; k++)
                     {
                         SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                     }
                 }
                 else if (Khoi == KHOI.KHOI_9)
                 {
                     for (int k = 0; k < _ListMonHoc[i].SoTiet; k++)
                     {
                         SoTietHocTrongTuan.Add(_ListMonHoc[i]);
                     }
                 }
             }

             ChuongTrinhHocService CtrHoc = null;

             if (Khoi == KHOI.KHOI_6)
                 CtrHoc = new ChuongTrinhHocService(SoTietHocTrongTuan, KHOI6);
             else if (Khoi == KHOI.KHOI_7)
                 CtrHoc = new ChuongTrinhHocService(SoTietHocTrongTuan, KHOI7);
             else if (Khoi == KHOI.KHOI_8)
                 CtrHoc = new ChuongTrinhHocService(SoTietHocTrongTuan, KHOI8);
             else if (Khoi == KHOI.KHOI_9)
                 CtrHoc = new ChuongTrinhHocService(SoTietHocTrongTuan, KHOI9);

             return CtrHoc;
         }
         public GiaoVien[][] TaoDanhSachGiaoVienTheoMon()
         {
                 GiaoVien[][] DsGiaoVienTheoMon = new GiaoVien[_ListMonHoc.Count][];

                 for (int i = 0; i < DsGiaoVienTheoMon.Count(); i++)
                 {
                     DsGiaoVienTheoMon[i] = _GiaoVienService.LayDanhSachGiaoVienTheoMon(_ListMonHoc[i].MaMonHoc).ToArray();
                 }
                 return DsGiaoVienTheoMon;
         }

         public void CreateQuanTheBanDau(int MaNamHoc, string MaHocKy)
         {
             _QuanTheBanDau = CreateTKB_ToanTruong(MaNamHoc, MaHocKy);
         }

         /// <summary>
         /// Lập thời khóa biểu cho toàn trường
         /// </summary>
         /// <returns></returns>
         public LichGiangDay[][] CreateTKB_ToanTruong(int MaNamHoc, string MaHocKy)
         {
             // Cấp phát vùng nhớ
             LichGiangDay[][] TKB_ToanTruong = new LichGiangDay[_ListLop.Count][];

             for (int i = 0; i < TKB_ToanTruong.Count(); i++)
             {
                 TKB_ToanTruong[i] = CreateTKB_Lop(_ListLop[i],MaNamHoc,MaHocKy);
             }

             return TKB_ToanTruong;
         }

         public void LayDanhSachGiaoVienTheoMon(ChuongTrinhHocService chuongTrinhHocLop)
         {
             Random rand = new Random();
             int index = 0;

             for (int i = 0; i < chuongTrinhHocLop.chuongTrinhHoc.Count; i++)
             {
                 if (i < chuongTrinhHocLop.chuongTrinhHoc.Count - 1)
                 {
                     if (chuongTrinhHocLop.chuongTrinhHoc[i].MaMonHoc != chuongTrinhHocLop.chuongTrinhHoc[i + 1].MaMonHoc)
                         index = rand.Next(0, _ListGiaoVienTheoMon[_ListMonHoc.IndexOf(chuongTrinhHocLop.chuongTrinhHoc[i])].Count());
                     else if (i == 0)
                         index = rand.Next(0, _ListGiaoVienTheoMon[_ListMonHoc.IndexOf(chuongTrinhHocLop.chuongTrinhHoc[i])].Count());
                 }

                 _ListGiaoVien.Add(_ListGiaoVienTheoMon[_ListMonHoc.IndexOf(chuongTrinhHocLop.chuongTrinhHoc[i])][index]);
             }
         }
       
         public LichGiangDay[] CreateTKB_Lop(LopHoc lop, int MaNamHoc, string MaHocKy)
         {
             LichGiangDay[] TKB_Khoi = new LichGiangDay[_SOTIETHOCTRONGTUAN]; // khởi tạo số tiết tối đa trong tuần là 70 tiết
             List<int> SoTietHocTrongTuan = new List<int>();
             for (int i = 0; i < _SOTIETHOCTRONGTUAN; i++)
                 SoTietHocTrongTuan.Add(i);

             Random rand = new Random();
             int index = 0;
             for (int i = 0; i < _ListChuongTrinhHoc.Count; i++)
             {
                 if (_ListChuongTrinhHoc[i].maKhoi.Equals(lop.MaKhoi.ToString()))// lấy chương trình học đúng với lớp 
                 {
                     LayDanhSachGiaoVienTheoMon(_ListChuongTrinhHoc[i]);

                     //List<GiaoVien> listGiaoVienCuoiCungTheoMon = LayDanhSachNhungGiaoVienCuoiTheoMon(_ListGiaoVien);

                     for (int j = 0; j < _ListGiaoVien.Count; j++)
                     {
                         if (SoTietHocTrongTuan.Count > 0)
                         {
                             index = rand.Next(0, SoTietHocTrongTuan.Count);
                             LichGiangDay lich = new LichGiangDay();
                             CT_LichGiangDay ct = new CT_LichGiangDay();

                             lich.MaHocKy = MaHocKy;
                             lich.MaNamHoc = MaNamHoc;
                             lich.MaPhongHoc = int.Parse(lop.MaPhong);
                             lich.MaTietHoc = SoTietHocTrongTuan.Count() % 5 +1 ;
                             lich.MaMonHoc = _MonHocService.LayMonHocTheoMaGiaoVien(_ListGiaoVien[j].PersonId).First().MaMonHoc;
                             lich.MaLopHoc = lop.MaLopHoc;
                             int thu = (SoTietHocTrongTuan.Count() / 5 + 2);
                             if(thu>=7) thu = 7;
                             lich.Thu = "Thu " +  thu;

                             ct.MaGiaoVien = _ListGiaoVien[j].PersonId;
                             ct.MaLichGiangDay = lich.MaLichGiangDay;
                             ct.NgayBatDau = new DateTime(2016, 1, 20);
                             ct.NgayKetThuc = new DateTime(2016, 6, 12);

                             lich.dsCT_LichGiangDay.Add(ct);
                             TKB_Khoi[SoTietHocTrongTuan[index]] = lich;

                             SoTietHocTrongTuan.RemoveAt(index);
                         }
                     }

                     break;
                 }
             }

             return TKB_Khoi;
         }

         public int KiemTraTietDayCoBiTrung(LichGiangDay[][] TKB_Truong, int rows, int column)
         {
             int rowtrung = -1;

             for (int i = 0; i < TKB_Truong.Count(); i++)
             {
                 for (int j = 0; j < TKB_Truong[i].Count(); j++)
                 {
                     if ( TKB_Truong[i][j] == null || (i==rows && j==column)) continue;

                     if (TKB_Truong[i][j].MaMonHoc.Equals(TKB_Truong[rows][column].MaMonHoc) 
                         && TKB_Truong[i][j].dsCT_LichGiangDay.First().MaGiaoVien.Equals(TKB_Truong[rows][column].dsCT_LichGiangDay.First().MaGiaoVien)
                         && TKB_Truong[i][j].MaTietHoc==TKB_Truong[rows][column].MaTietHoc
                         && TKB_Truong[i][j].Thu==TKB_Truong[rows][column].Thu  )
                     {
                         TKB_Truong[i][j].MaTietHoc = TKB_Truong[i][j].MaTietHoc- 1;
                         if (TKB_Truong[i][j].MaTietHoc - 1 <= 0) TKB_Truong[i][j].MaTietHoc = 5;
                         
                         rowtrung = 1;
                     }
                 }
             }
             return rowtrung;
         }


         public Boolean CapNhatMonHocBiTrungTKB()
         {
             int rows = _QuanTheBanDau.Count();
             int columns = _QuanTheBanDau[0].Count();
            
             for (int i = 0; i < rows; i++)
             {
                 for (int j = 0; j< columns; j++)
                 {
                     if (_QuanTheBanDau[i][j] == null) continue;

                     if (KiemTraTietDayCoBiTrung(_QuanTheBanDau, i,j) == -1) // khong bi trung tiet day
                         continue;
                 }
             }

             return true;
         }

         public List<LichGiangDay> layThoiKhoaBieu()
         {
             List<LichGiangDay> ListGiangDay = new List<LichGiangDay>();
             for (int row = 0; row < _QuanTheBanDau.Count(); row++)
             {
                 for (int i = 0; i < _QuanTheBanDau[row].Count(); i++)
                 {
                    if(_QuanTheBanDau[row][i]!=null) ListGiangDay.Add(_QuanTheBanDau[row][i]);
                 }
             }
             return ListGiangDay;
         }
         public void AddDsGiangDay(List<LichGiangDay> dsGiangDay)
         {
             _TKBRepository.Insert(dsGiangDay);
         }
         public IEnumerable<ThoiKhoaBieuViewModel> KhoiTaoViewModel()
         {
             return _CTLichGiangDayRepository.Entities.Where(c => c.Active)
                 .Join(_TKBRepository.Entities.Where(e => e.Active)
                 , a => a.MaLichGiangDay
                , b => b.MaLichGiangDay
                , (a, b) => new { a, b })
                .Join(_GiaoVienRepository.Entities.Where(d => d.Active)
                 , c => c.a.MaGiaoVien
                , d => d.PersonId
                 , (c, d) => new { c, d })
                 .Join(_GiaoVienMonHocRepository.Entities.Where(d => d.Active)
                 , e => e.d.PersonId
                , f => f.MaGiaoVien
                , (e, f) => new { e, f })
                .Join(_MonHocRepository.Entities.Where(d => d.Active)
                , g => g.f.MaMonHoc
                , h => h.MaMonHoc
                , (g, h) => new { g, h })
                .Join(_LopHocRepository.Entities.Where(d => d.Active)
                , j => j.g.e.c.b.MaLopHoc
                , k => k.MaLopHoc
                 , (j, k)  =>new {j,k})
                 .Join(_NamHocRepository.Entities.Where(a=>a.Active)
                 ,l=>l.j.g.e.c.b.MaNamHoc
                 ,q=>q.MaNamHoc
                 ,(l,q) =>new {l,q})
                 .Join(_PhongHocRepository.Entities.Where(a=>a.Active)
                 ,w=>w.l.j.g.e.c.b.MaPhongHoc
                 ,r=>r.MaPhong
                 ,(w,r)=>new {w,r})
                 .Join(_HocKyRepository.Entities.Where(a=>a.Active)
                 ,t=>t.w.l.j.g.e.c.b.MaHocKy
                 ,y=>y.MaHocKy
                 ,(t,y) => new ThoiKhoaBieuViewModel()
                 {
                     MaGiaoVien=t.w.l.j.g.e.c.a.MaGiaoVien,
                     MaHocKy = t.w.l.j.g.e.c.b.MaHocKy,
                     MaLichGiangDay = t.w.l.j.g.e.c.b.MaLichGiangDay,
                     MaLopHoc = t.w.l.j.g.e.c.b.MaLopHoc,
                     MaMonHoc = t.w.l.j.g.e.c.b.MaMonHoc,
                     MaNamHoc = t.w.l.j.g.e.c.b.MaNamHoc,
                     MaPhongHoc = t.w.l.j.g.e.c.b.MaPhongHoc,
                     MaTietHoc = t.w.l.j.g.e.c.b.MaTietHoc,
                     TenGiaoVien = t.w.l.j.g.e.d.HoTen,
                     TenMonHoc = t.w.l.j.h.TenMonHoc,
                     TenLopHoc = t.w.l.k.TenLop,
                     Thu = t.w.l.j.g.e.c.b.Thu,
                     TenHocKy =y.TenHocKy,
                     TenPhongHoc = t.r.TenPhong,
                     TenNamHoc = t.w.q.NamBatDau + " - " + t.w.q.NamKetThuc
                 });
             
            
                

         }
    }

}
