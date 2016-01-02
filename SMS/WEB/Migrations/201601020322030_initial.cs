namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangDiemHKMH",
                c => new
                    {
                        MaBangDiem = c.Int(nullable: false, identity: true),
                        MaHocSinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocKy = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaMonHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangDiem)
                .ForeignKey("dbo.HocKyNamHoc", t => new { t.MaHocKy, t.MaNamHoc })
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh)
                .ForeignKey("dbo.MonHoc", t => t.MaMonHoc)
                .Index(t => t.MaHocSinh)
                .Index(t => new { t.MaHocKy, t.MaNamHoc })
                .Index(t => t.MaMonHoc);
            
            CreateTable(
                "dbo.CotDiem",
                c => new
                    {
                        MaCotDiem = c.Int(nullable: false, identity: true),
                        MaBangDiem = c.Int(nullable: false),
                        MaLoaiDiem = c.Int(nullable: false),
                        TenCotDiem = c.String(nullable: false, maxLength: 50),
                        GiaTri = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaCotDiem)
                .ForeignKey("dbo.LoaiDiem", t => t.MaLoaiDiem)
                .ForeignKey("dbo.BangDiemHKMH", t => t.MaBangDiem)
                .Index(t => t.MaBangDiem)
                .Index(t => t.MaLoaiDiem);
            
            CreateTable(
                "dbo.LoaiDiem",
                c => new
                    {
                        MaLoaiDiem = c.Int(nullable: false, identity: true),
                        TenLoaiDiem = c.String(nullable: false, maxLength: 100),
                        HeSo = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiDiem);
            
            CreateTable(
                "dbo.HocKyNamHoc",
                c => new
                    {
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocKy = c.String(nullable: false, maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaNamHoc, t.MaHocKy })
                .ForeignKey("dbo.NamHoc", t => t.MaNamHoc)
                .ForeignKey("dbo.HocKy", t => t.MaHocKy)
                .Index(t => t.MaNamHoc)
                .Index(t => t.MaHocKy);
            
            CreateTable(
                "dbo.LichGiangDay",
                c => new
                    {
                        MaLichGiangDay = c.Int(nullable: false, identity: true),
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocKy = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaLopHoc = c.Int(nullable: false),
                        MaMonHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaTietHoc = c.Int(nullable: false),
                        MaPhongHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        Thu = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaLichGiangDay)
                .ForeignKey("dbo.LopHoc", t => t.MaLopHoc)
                .ForeignKey("dbo.PhongHoc", t => t.MaPhongHoc)
                .ForeignKey("dbo.MonHoc", t => t.MaMonHoc)
                .ForeignKey("dbo.TietHoc", t => t.MaTietHoc)
                .ForeignKey("dbo.HocKyNamHoc", t => new { t.MaHocKy, t.MaNamHoc })
                .Index(t => new { t.MaHocKy, t.MaNamHoc })
                .Index(t => t.MaLopHoc)
                .Index(t => t.MaMonHoc)
                .Index(t => t.MaTietHoc)
                .Index(t => t.MaPhongHoc);
            
            CreateTable(
                "dbo.CT_LichGiangDay",
                c => new
                    {
                        MaLichGiangDay = c.Int(nullable: false),
                        MaGiaoVien = c.String(nullable: false, maxLength: 50, unicode: false),
                        NgayBatDau = c.DateTime(nullable: false, storeType: "date"),
                        NgayKetThuc = c.DateTime(storeType: "date"),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaLichGiangDay, t.MaGiaoVien })
                .ForeignKey("dbo.GiaoVien", t => t.MaGiaoVien)
                .ForeignKey("dbo.LichGiangDay", t => t.MaLichGiangDay)
                .Index(t => t.MaLichGiangDay)
                .Index(t => t.MaGiaoVien);
            
            CreateTable(
                "dbo.Nguoi",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 50, unicode: false),
                        PersonTypeId = c.Int(nullable: false),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        GioiTinh = c.Boolean(nullable: false),
                        NgaySinh = c.DateTime(nullable: false, storeType: "date"),
                        NoiSinh = c.String(nullable: false, maxLength: 200),
                        DiaChi = c.String(nullable: false, maxLength: 200),
                        CMND = c.String(nullable: false, maxLength: 50, unicode: false),
                        SDT = c.String(nullable: false, maxLength: 50, unicode: false),
                        TonGiao = c.String(),
                        DanToc = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.PersonType", t => t.PersonTypeId)
                .Index(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.ThongTinKhenThuong",
                c => new
                    {
                        MaTTKhenThuong = c.Int(nullable: false, identity: true),
                        MaGiaoVien = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocSinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaTietHoc = c.Int(nullable: false),
                        NoiDungKhenThuong = c.String(nullable: false, maxLength: 500),
                        NgayKhenThuong = c.DateTime(nullable: false, storeType: "date"),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTTKhenThuong)
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh)
                .ForeignKey("dbo.TietHoc", t => t.MaTietHoc)
                .ForeignKey("dbo.GiaoVien", t => t.MaGiaoVien)
                .Index(t => t.MaGiaoVien)
                .Index(t => t.MaHocSinh)
                .Index(t => t.MaTietHoc);
            
            CreateTable(
                "dbo.CT_QuyetDinhKhenThuong",
                c => new
                    {
                        SoQuyetDinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocSinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        LyDoKhenThuong = c.String(nullable: false, maxLength: 200),
                        HinhThucKhenThuong = c.String(nullable: false, maxLength: 200),
                        GiaTriKhenThuong = c.Long(),
                        GhiVaoHocBa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SoQuyetDinh, t.MaHocSinh })
                .ForeignKey("dbo.QuyetDinhKhenThuong", t => t.SoQuyetDinh)
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh)
                .Index(t => t.SoQuyetDinh)
                .Index(t => t.MaHocSinh);
            
            CreateTable(
                "dbo.QuyetDinhKhenThuong",
                c => new
                    {
                        SoQuyetDinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        NgayQD = c.DateTime(nullable: false, storeType: "date"),
                        NoiDungQD = c.String(nullable: false, maxLength: 200),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SoQuyetDinh)
                .ForeignKey("dbo.NamHoc", t => t.MaNamHoc)
                .Index(t => t.MaNamHoc);
            
            CreateTable(
                "dbo.NamHoc",
                c => new
                    {
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        NamBatDau = c.Int(nullable: false),
                        NamKetThuc = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaNamHoc);
            
            CreateTable(
                "dbo.LopHoc",
                c => new
                    {
                        MaLopHoc = c.Int(nullable: false, identity: true),
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaKhoi = c.Int(nullable: false),
                        MaPhong = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenLop = c.String(nullable: false, maxLength: 50),
                        SiSo = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaLopHoc)
                .ForeignKey("dbo.KhoiLop", t => t.MaKhoi)
                .ForeignKey("dbo.NamHoc", t => t.MaNamHoc)
                .Index(t => t.MaNamHoc)
                .Index(t => t.MaKhoi);
            
            CreateTable(
                "dbo.TTDKPhongHocChinh",
                c => new
                    {
                        MaPhong = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaLop = c.Int(nullable: false),
                        NgayDangKy = c.DateTime(nullable: false, storeType: "date"),
                        BuoiHoc = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaPhong, t.MaLop })
                .ForeignKey("dbo.PhongHoc", t => t.MaPhong)
                .ForeignKey("dbo.LopHoc", t => t.MaLop)
                .Index(t => t.MaPhong)
                .Index(t => t.MaLop);
            
            CreateTable(
                "dbo.PhongHoc",
                c => new
                    {
                        MaPhong = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenPhong = c.String(maxLength: 50),
                        SucChua = c.Int(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhong);
            
            CreateTable(
                "dbo.KhoiLop",
                c => new
                    {
                        MaKhoi = c.Int(nullable: false, identity: true),
                        TenKhoi = c.String(maxLength: 100),
                        BuoiHoc = c.String(nullable: false, maxLength: 100),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoi);
            
            CreateTable(
                "dbo.MonHocKhoi",
                c => new
                    {
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaKhoi = c.Int(nullable: false),
                        MaMonHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaNamHoc, t.MaKhoi, t.MaMonHoc })
                .ForeignKey("dbo.MonHoc", t => t.MaMonHoc)
                .ForeignKey("dbo.KhoiLop", t => t.MaKhoi)
                .ForeignKey("dbo.NamHoc", t => t.MaNamHoc)
                .Index(t => t.MaNamHoc)
                .Index(t => t.MaKhoi)
                .Index(t => t.MaMonHoc);
            
            CreateTable(
                "dbo.MonHoc",
                c => new
                    {
                        MaMonHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenMonHoc = c.String(nullable: false, maxLength: 100),
                        HeSo = c.Single(nullable: false),
                        SoTiet = c.Int(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaMonHoc);
            
            CreateTable(
                "dbo.QuyetDinhKyLuat",
                c => new
                    {
                        SoQuyetDinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaNamHoc = c.String(nullable: false, maxLength: 50, unicode: false),
                        NgayQD = c.DateTime(nullable: false, storeType: "date"),
                        NoiDungQD = c.String(nullable: false, maxLength: 200),
                        NgayHieuLuc = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.SoQuyetDinh)
                .ForeignKey("dbo.NamHoc", t => t.MaNamHoc)
                .Index(t => t.MaNamHoc);
            
            CreateTable(
                "dbo.CT_QuyetDinhKyLuat",
                c => new
                    {
                        SoQuyetDinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocSinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        LyDoKyLuat = c.String(nullable: false, maxLength: 200),
                        HinhThucKyLuat = c.String(nullable: false, maxLength: 200),
                        GhiVaoHocBa = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.SoQuyetDinh, t.MaHocSinh })
                .ForeignKey("dbo.QuyetDinhKyLuat", t => t.SoQuyetDinh)
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh)
                .Index(t => t.SoQuyetDinh)
                .Index(t => t.MaHocSinh);
            
            CreateTable(
                "dbo.ThongTinKyLuat",
                c => new
                    {
                        MaTTKyLuat = c.Int(nullable: false, identity: true),
                        MaGiaoVien = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaHocSinh = c.String(nullable: false, maxLength: 50, unicode: false),
                        MaTietHoc = c.Int(nullable: false),
                        NoiDungKyLuat = c.String(nullable: false, maxLength: 500),
                        NgayKyLuat = c.DateTime(nullable: false, storeType: "date"),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTTKyLuat)
                .ForeignKey("dbo.TietHoc", t => t.MaTietHoc)
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh)
                .ForeignKey("dbo.GiaoVien", t => t.MaGiaoVien)
                .Index(t => t.MaGiaoVien)
                .Index(t => t.MaHocSinh)
                .Index(t => t.MaTietHoc);
            
            CreateTable(
                "dbo.TietHoc",
                c => new
                    {
                        MaTietHoc = c.Int(nullable: false, identity: true),
                        GioBatDau = c.Time(nullable: false, precision: 7),
                        GioKetThuc = c.Time(nullable: false, precision: 7),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaTietHoc);
            
            CreateTable(
                "dbo.PersonType",
                c => new
                    {
                        PersonTypeId = c.Int(nullable: false, identity: true),
                        PersonTypeName = c.String(nullable: false, maxLength: 100),
                        Prefix = c.String(maxLength: 50, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.HocKy",
                c => new
                    {
                        MaHocKy = c.String(nullable: false, maxLength: 50, unicode: false),
                        TenHocKy = c.String(nullable: false, maxLength: 100),
                        HeSo = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaHocKy);
            
            CreateTable(
                "dbo.GiaoVien",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Nguoi", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.HocSinh",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 50, unicode: false),
                        HoTenCha = c.String(nullable: false, maxLength: 100),
                        NgheNghiepCha = c.String(nullable: false, maxLength: 100),
                        HoTenMe = c.String(nullable: false, maxLength: 100),
                        NgheNghiepMe = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Nguoi", t => t.PersonId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HocSinh", "PersonId", "dbo.Nguoi");
            DropForeignKey("dbo.GiaoVien", "PersonId", "dbo.Nguoi");
            DropForeignKey("dbo.HocKyNamHoc", "MaHocKy", "dbo.HocKy");
            DropForeignKey("dbo.LichGiangDay", new[] { "MaHocKy", "MaNamHoc" }, "dbo.HocKyNamHoc");
            DropForeignKey("dbo.CT_LichGiangDay", "MaLichGiangDay", "dbo.LichGiangDay");
            DropForeignKey("dbo.ThongTinKyLuat", "MaGiaoVien", "dbo.GiaoVien");
            DropForeignKey("dbo.ThongTinKhenThuong", "MaGiaoVien", "dbo.GiaoVien");
            DropForeignKey("dbo.Nguoi", "PersonTypeId", "dbo.PersonType");
            DropForeignKey("dbo.ThongTinKyLuat", "MaHocSinh", "dbo.HocSinh");
            DropForeignKey("dbo.ThongTinKyLuat", "MaTietHoc", "dbo.TietHoc");
            DropForeignKey("dbo.ThongTinKhenThuong", "MaTietHoc", "dbo.TietHoc");
            DropForeignKey("dbo.LichGiangDay", "MaTietHoc", "dbo.TietHoc");
            DropForeignKey("dbo.ThongTinKhenThuong", "MaHocSinh", "dbo.HocSinh");
            DropForeignKey("dbo.CT_QuyetDinhKyLuat", "MaHocSinh", "dbo.HocSinh");
            DropForeignKey("dbo.CT_QuyetDinhKhenThuong", "MaHocSinh", "dbo.HocSinh");
            DropForeignKey("dbo.QuyetDinhKyLuat", "MaNamHoc", "dbo.NamHoc");
            DropForeignKey("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh", "dbo.QuyetDinhKyLuat");
            DropForeignKey("dbo.QuyetDinhKhenThuong", "MaNamHoc", "dbo.NamHoc");
            DropForeignKey("dbo.MonHocKhoi", "MaNamHoc", "dbo.NamHoc");
            DropForeignKey("dbo.LopHoc", "MaNamHoc", "dbo.NamHoc");
            DropForeignKey("dbo.MonHocKhoi", "MaKhoi", "dbo.KhoiLop");
            DropForeignKey("dbo.MonHocKhoi", "MaMonHoc", "dbo.MonHoc");
            DropForeignKey("dbo.LichGiangDay", "MaMonHoc", "dbo.MonHoc");
            DropForeignKey("dbo.BangDiemHKMH", "MaMonHoc", "dbo.MonHoc");
            DropForeignKey("dbo.LopHoc", "MaKhoi", "dbo.KhoiLop");
            DropForeignKey("dbo.TTDKPhongHocChinh", "MaLop", "dbo.LopHoc");
            DropForeignKey("dbo.TTDKPhongHocChinh", "MaPhong", "dbo.PhongHoc");
            DropForeignKey("dbo.LichGiangDay", "MaPhongHoc", "dbo.PhongHoc");
            DropForeignKey("dbo.LichGiangDay", "MaLopHoc", "dbo.LopHoc");
            DropForeignKey("dbo.HocKyNamHoc", "MaNamHoc", "dbo.NamHoc");
            DropForeignKey("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh", "dbo.QuyetDinhKhenThuong");
            DropForeignKey("dbo.BangDiemHKMH", "MaHocSinh", "dbo.HocSinh");
            DropForeignKey("dbo.CT_LichGiangDay", "MaGiaoVien", "dbo.GiaoVien");
            DropForeignKey("dbo.BangDiemHKMH", new[] { "MaHocKy", "MaNamHoc" }, "dbo.HocKyNamHoc");
            DropForeignKey("dbo.CotDiem", "MaBangDiem", "dbo.BangDiemHKMH");
            DropForeignKey("dbo.CotDiem", "MaLoaiDiem", "dbo.LoaiDiem");
            DropIndex("dbo.HocSinh", new[] { "PersonId" });
            DropIndex("dbo.GiaoVien", new[] { "PersonId" });
            DropIndex("dbo.ThongTinKyLuat", new[] { "MaTietHoc" });
            DropIndex("dbo.ThongTinKyLuat", new[] { "MaHocSinh" });
            DropIndex("dbo.ThongTinKyLuat", new[] { "MaGiaoVien" });
            DropIndex("dbo.CT_QuyetDinhKyLuat", new[] { "MaHocSinh" });
            DropIndex("dbo.CT_QuyetDinhKyLuat", new[] { "SoQuyetDinh" });
            DropIndex("dbo.QuyetDinhKyLuat", new[] { "MaNamHoc" });
            DropIndex("dbo.MonHocKhoi", new[] { "MaMonHoc" });
            DropIndex("dbo.MonHocKhoi", new[] { "MaKhoi" });
            DropIndex("dbo.MonHocKhoi", new[] { "MaNamHoc" });
            DropIndex("dbo.TTDKPhongHocChinh", new[] { "MaLop" });
            DropIndex("dbo.TTDKPhongHocChinh", new[] { "MaPhong" });
            DropIndex("dbo.LopHoc", new[] { "MaKhoi" });
            DropIndex("dbo.LopHoc", new[] { "MaNamHoc" });
            DropIndex("dbo.QuyetDinhKhenThuong", new[] { "MaNamHoc" });
            DropIndex("dbo.CT_QuyetDinhKhenThuong", new[] { "MaHocSinh" });
            DropIndex("dbo.CT_QuyetDinhKhenThuong", new[] { "SoQuyetDinh" });
            DropIndex("dbo.ThongTinKhenThuong", new[] { "MaTietHoc" });
            DropIndex("dbo.ThongTinKhenThuong", new[] { "MaHocSinh" });
            DropIndex("dbo.ThongTinKhenThuong", new[] { "MaGiaoVien" });
            DropIndex("dbo.Nguoi", new[] { "PersonTypeId" });
            DropIndex("dbo.CT_LichGiangDay", new[] { "MaGiaoVien" });
            DropIndex("dbo.CT_LichGiangDay", new[] { "MaLichGiangDay" });
            DropIndex("dbo.LichGiangDay", new[] { "MaPhongHoc" });
            DropIndex("dbo.LichGiangDay", new[] { "MaTietHoc" });
            DropIndex("dbo.LichGiangDay", new[] { "MaMonHoc" });
            DropIndex("dbo.LichGiangDay", new[] { "MaLopHoc" });
            DropIndex("dbo.LichGiangDay", new[] { "MaHocKy", "MaNamHoc" });
            DropIndex("dbo.HocKyNamHoc", new[] { "MaHocKy" });
            DropIndex("dbo.HocKyNamHoc", new[] { "MaNamHoc" });
            DropIndex("dbo.CotDiem", new[] { "MaLoaiDiem" });
            DropIndex("dbo.CotDiem", new[] { "MaBangDiem" });
            DropIndex("dbo.BangDiemHKMH", new[] { "MaMonHoc" });
            DropIndex("dbo.BangDiemHKMH", new[] { "MaHocKy", "MaNamHoc" });
            DropIndex("dbo.BangDiemHKMH", new[] { "MaHocSinh" });
            DropTable("dbo.HocSinh");
            DropTable("dbo.GiaoVien");
            DropTable("dbo.HocKy");
            DropTable("dbo.PersonType");
            DropTable("dbo.TietHoc");
            DropTable("dbo.ThongTinKyLuat");
            DropTable("dbo.CT_QuyetDinhKyLuat");
            DropTable("dbo.QuyetDinhKyLuat");
            DropTable("dbo.MonHoc");
            DropTable("dbo.MonHocKhoi");
            DropTable("dbo.KhoiLop");
            DropTable("dbo.PhongHoc");
            DropTable("dbo.TTDKPhongHocChinh");
            DropTable("dbo.LopHoc");
            DropTable("dbo.NamHoc");
            DropTable("dbo.QuyetDinhKhenThuong");
            DropTable("dbo.CT_QuyetDinhKhenThuong");
            DropTable("dbo.ThongTinKhenThuong");
            DropTable("dbo.Nguoi");
            DropTable("dbo.CT_LichGiangDay");
            DropTable("dbo.LichGiangDay");
            DropTable("dbo.HocKyNamHoc");
            DropTable("dbo.LoaiDiem");
            DropTable("dbo.CotDiem");
            DropTable("dbo.BangDiemHKMH");
        }
    }
}
