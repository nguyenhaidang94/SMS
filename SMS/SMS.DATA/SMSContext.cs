namespace SMS.DATA
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CORE.Data;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SMSContext : DbContext
    {
        public SMSContext()
            : base("name=SMSContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<BangDiemHKMH> DbBangDiemHKNH { get; set; }
        public virtual DbSet<CotDiem> DbCotDiem { get; set; }
        public virtual DbSet<CT_LichGiangDay> DbCT_LichGD { get; set; }
        public virtual DbSet<CT_QuyetDinhKhenThuong> DbCT_QDKhenThuong { get; set; }
        public virtual DbSet<CT_QuyetDinhKyLuat> DbCT_QDKyLuat { get; set; }
        public virtual DbSet<HocKy> DbHocKy { get; set; }
        public virtual DbSet<HocKyNamHoc> DbHocKyNamHoc { get; set; }
        public virtual DbSet<KhoiLop> DbKhoiLop { get; set; }
        public virtual DbSet<LichGiangDay> DbLichGD { get; set; }
        public virtual DbSet<LoaiDiem> DbLoaiDiem { get; set; }
        public virtual DbSet<LopHoc> DbLopHoc { get; set; }
        public virtual DbSet<MonHoc> DbMonHoc { get; set; }
        public virtual DbSet<MonHocKhoi> DbMonHocKhoi { get; set; }
        public virtual DbSet<NamHoc> DbNamHoc { get; set; }
        public virtual DbSet<Nguoi> DbNguoi { get; set; }
        public virtual DbSet<PersonType> DbPersonType { get; set; }
        public virtual DbSet<PhongHoc> DbPhongHoc { get; set; }
        public virtual DbSet<QuyetDinhKhenThuong> DbQDKhenThuong { get; set; }
        public virtual DbSet<QuyetDinhKyLuat> DbQDKyLuat { get; set; }
        public virtual DbSet<ThongTinKhenThuong> DbTTKhenThuong { get; set; }
        public virtual DbSet<ThongTinKyLuat> DbTTKyLuat { get; set; }
        public virtual DbSet<TietHoc> DbTietHoc { get; set; }
        public virtual DbSet<TTDKPhongHocChinh> DbTTDKPhongHocChinh { get; set; }
        public virtual DbSet<ThamSo> DbThamSo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //map inheritance relationship
            modelBuilder.Entity<GiaoVien>().ToTable("GiaoVien");
            modelBuilder.Entity<HocSinh>().ToTable("HocSinh");

            //map cotdiem to bang diem
            modelBuilder.Entity<BangDiemHKMH>()
                .HasMany(e => e.dsCotDiem)
                .WithRequired(o => o.BangDiemHKMH)
                .HasForeignKey(o => o.MaBangDiem)
                .WillCascadeOnDelete(false);

            //map ct_lichgiangday to giaovien
            modelBuilder.Entity<GiaoVien>()
                .HasMany(e => e.dsCT_LichGiangDay)
                .WithRequired(o => o.GiaoVien)
                .HasForeignKey(o => o.MaGiaoVien)
                .WillCascadeOnDelete(false);

            //map thongtinkhenthuong to giaovien
            modelBuilder.Entity<GiaoVien>()
               .HasMany(e => e.dsThongTinKhenThuong)
               .WithRequired(o => o.GiaoVien)
               .HasForeignKey(o => o.MaGiaoVien)
               .WillCascadeOnDelete(false);

            //map thongtinkyluat to giaovien
            modelBuilder.Entity<GiaoVien>()
               .HasMany(e => e.dsThongTinKyLuat)
               .WithRequired(o => o.GiaoVien)
               .HasForeignKey(o => o.MaGiaoVien)
               .WillCascadeOnDelete(false);

            //map hockynamhoc to hocky
            modelBuilder.Entity<HocKy>()
               .HasMany(e => e.dsHocKyNamHoc)
               .WithRequired(o => o.HocKy)
               .HasForeignKey(o => o.MaHocKy)
               .WillCascadeOnDelete(false);

            //map bangdiemhknh to hockynamhoc
            modelBuilder.Entity<HocKyNamHoc>()
                .HasMany(e => e.dsBangDiemHKMH)
                .WithRequired(o => o.HocKyNamHoc)
                .HasForeignKey(o => new { o.MaNamHoc, o.MaHocKy })
                .WillCascadeOnDelete(false);

            //map lichgiangday to hockynamhoc
            modelBuilder.Entity<HocKyNamHoc>()
               .HasMany(e => e.dsLichGiangDay)
               .WithRequired(o => o.HocKyNamHoc)
               .HasForeignKey(o => new { o.MaNamHoc, o.MaHocKy })
               .WillCascadeOnDelete(false);

            //map n-n relationship
            modelBuilder.Entity<HocSinh>()
                .HasMany(e => e.dsLopHoc)
                .WithMany(e => e.dsHocSinh)
                .Map(m => m.ToTable("LopHoc_HocSinh").MapLeftKey("MaHocSinh").MapRightKey("MaLopHoc"));

            //map bangdiemhknh to hocsinh
            modelBuilder.Entity<HocSinh>()
                .HasMany(e => e.dsBangDiemHKMH)
                .WithRequired(o => o.HocSinh)
                .HasForeignKey(o => o.MaHocSinh)
                .WillCascadeOnDelete(false);

            //map ctqdkhenthuong to hocsinh
            modelBuilder.Entity<HocSinh>()
               .HasMany(e => e.dsCTQDKhenThuong)
               .WithRequired(o => o.HocSinh)
               .HasForeignKey(o => o.MaHocSinh)
               .WillCascadeOnDelete(false);

            //map ctqdkyluat to hocsinh
            modelBuilder.Entity<HocSinh>()
               .HasMany(e => e.dsCTQDKyLuat)
               .WithRequired(o => o.HocSinh)
               .HasForeignKey(o => o.MaHocSinh)
               .WillCascadeOnDelete(false);

            //map thongtinkhenthuong to hocsinh
            modelBuilder.Entity<HocSinh>()
               .HasMany(e => e.dsThongTinKhenThuong)
               .WithRequired(o => o.HocSinh)
               .HasForeignKey(o => o.MaHocSinh)
               .WillCascadeOnDelete(false);

            //map thongtinkyluat to hocsinh
            modelBuilder.Entity<HocSinh>()
               .HasMany(e => e.dsThongTinKyLuat)
               .WithRequired(o => o.HocSinh)
               .HasForeignKey(o => o.MaHocSinh)
               .WillCascadeOnDelete(false);

            //map lophoc to khoilop
            modelBuilder.Entity<KhoiLop>()
                .HasMany(e => e.dsLopHoc)
                .WithRequired(e => e.KhoiLop)
                .HasForeignKey(e => e.MaKhoi)
                .WillCascadeOnDelete(false);

            //map monhockhoi to khoilop
            modelBuilder.Entity<KhoiLop>()
                .HasMany(e => e.dsMonHocKhoi)
                .WithRequired(e => e.KhoiLop)
                .HasForeignKey(e => e.MaKhoi)
                .WillCascadeOnDelete(false);

            //map ctlichgiangday to lichgiangday
            modelBuilder.Entity<LichGiangDay>()
                .HasMany(e => e.dsCT_LichGiangDay)
                .WithRequired(o => o.LichGiangDay)
                .HasForeignKey(o => o.MaLichGiangDay)
                .WillCascadeOnDelete(false);

            //map cotdiem to loaidiem
            modelBuilder.Entity<LoaiDiem>()
                .HasMany(e => e.dsCotDiem)
                .WithRequired(o => o.LoaiDiem)
                .HasForeignKey(o => o.MaLoaiDiem)
                .WillCascadeOnDelete(false);

            //map lichgiangday to lophoc
            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.dsLichGiangDay)
                .WithRequired(o => o.LopHoc)
                .HasForeignKey(o => o.MaLopHoc)
                .WillCascadeOnDelete(false);

            //map ttdkphonghocchinh to lophoc
            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.dsTTDKPhongHocChinh)
                .WithRequired(o => o.LopHoc)
                .HasForeignKey(o => o.MaLop)
                .WillCascadeOnDelete(false);

            //map bangdiemhkmh to monhoc
            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.dsBangDiemHKMH)
                .WithRequired(o => o.MonHoc)
                .HasForeignKey(o => o.MaMonHoc)
                .WillCascadeOnDelete(false);

            //map lichgiangday to monhoc
            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.dsLichGiangDay)
                .WithRequired(o => o.MonHoc)
                .HasForeignKey(o => o.MaMonHoc)
                .WillCascadeOnDelete(false);

            //map monhockhoi to monhoc
            modelBuilder.Entity<MonHoc>()
                .HasMany(e => e.dsMonHocKhoi)
                .WithRequired(o => o.MonHoc)
                .HasForeignKey(o => o.MaMonHoc)
                .WillCascadeOnDelete(false);

            //map hockynamhoc to namhoc
            modelBuilder.Entity<NamHoc>()
               .HasMany(e => e.dsHocKyNamHoc)
               .WithRequired(o => o.NamHoc)
               .HasForeignKey(o => o.MaNamHoc)
               .WillCascadeOnDelete(false);

            //map lophoc to namhoc
            modelBuilder.Entity<NamHoc>()
               .HasMany(e => e.dsLopHoc)
               .WithRequired(o => o.NamHoc)
               .HasForeignKey(o => o.MaNamHoc)
               .WillCascadeOnDelete(false);

            //map monhockhoi to namhoc
            modelBuilder.Entity<NamHoc>()
               .HasMany(e => e.dsMonHocKhoi)
               .WithRequired(o => o.NamHoc)
               .HasForeignKey(o => o.MaNamHoc)
               .WillCascadeOnDelete(false);

            //map qdkhenthuong to namhoc
            modelBuilder.Entity<NamHoc>()
               .HasMany(e => e.dsQDKhenThuong)
               .WithRequired(o => o.NamHoc)
               .HasForeignKey(o => o.MaNamHoc)
               .WillCascadeOnDelete(false);

            //map qdkyluat to namhoc
            modelBuilder.Entity<NamHoc>()
               .HasMany(e => e.dsQDKyLuat)
               .WithRequired(o => o.NamHoc)
               .HasForeignKey(o => o.MaNamHoc)
               .WillCascadeOnDelete(false);

            //map nguoi to persontype
            modelBuilder.Entity<PersonType>()
                .HasMany(e => e.dsNguoi)
                .WithRequired(o => o.PersonType)
                .HasForeignKey(o => o.PersonTypeId)
                .WillCascadeOnDelete(false);

            //map lichgiangday to phonghoc
            modelBuilder.Entity<PhongHoc>()
                .HasMany(e => e.dsLichGiangDay)
                .WithRequired(o => o.PhongHoc)
                .HasForeignKey(o => o.MaPhongHoc)
                .WillCascadeOnDelete(false);

            //map ttdkphonghocchinh to phonghoc
            modelBuilder.Entity<PhongHoc>()
               .HasMany(e => e.dsTTDKPhongHocChinh)
               .WithRequired(o => o.PhongHoc)
               .HasForeignKey(o => o.MaPhong)
               .WillCascadeOnDelete(false);
            
            //map ctqdkhenthuong to qdkhenthuong
            modelBuilder.Entity<QuyetDinhKhenThuong>()
                .HasMany(e => e.dsCTQDKhenThuong)
                .WithRequired(o => o.QDKhenThuong)
                .HasForeignKey(o => o.MaQuyetDinh)
                .WillCascadeOnDelete(false);

            //map ctqdkyluat to qdkyluat
            modelBuilder.Entity<QuyetDinhKyLuat>()
                .HasMany(e => e.dsCTQDKyLuat)
                .WithRequired(o => o.QDKyLuat)
                .HasForeignKey(o => o.MaQuyetDinh)
                .WillCascadeOnDelete(false);

            //map thongtinkhenthuong to tiethoc
            modelBuilder.Entity<TietHoc>()
                .HasMany(e => e.dsTTKhenThuong)
                .WithRequired(o => o.TietHoc)
                .HasForeignKey(o => o.MaTietHoc)
                .WillCascadeOnDelete(false);

            //map thongtinkyluat to tiethoc
            modelBuilder.Entity<TietHoc>()
                .HasMany(e => e.dsTTKyLuat)
                .WithRequired(o => o.TietHoc)
                .HasForeignKey(o => o.MaTietHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TietHoc>()
                .HasMany(e => e.dsLichGD)
                .WithRequired(o => o.TietHoc)
                .HasForeignKey(o => o.MaTietHoc)
                .WillCascadeOnDelete(false);
        }
    }
}