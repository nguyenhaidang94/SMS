namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDTABLEGIAOVIENMONHOC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiaoVienMonHocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaGiaoVien = c.Int(nullable: false),
                        MaMonHoc = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MonHoc", t => t.MaMonHoc)
                .ForeignKey("dbo.GiaoVien", t => t.MaGiaoVien)
                .Index(t => t.MaGiaoVien)
                .Index(t => t.MaMonHoc);
            
            AddColumn("dbo.GiaoVien", "CMND", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Nguoi", "CMND");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nguoi", "CMND", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropForeignKey("dbo.GiaoVienMonHocs", "MaGiaoVien", "dbo.GiaoVien");
            DropForeignKey("dbo.GiaoVienMonHocs", "MaMonHoc", "dbo.MonHoc");
            DropIndex("dbo.GiaoVienMonHocs", new[] { "MaMonHoc" });
            DropIndex("dbo.GiaoVienMonHocs", new[] { "MaGiaoVien" });
            DropColumn("dbo.GiaoVien", "CMND");
            DropTable("dbo.GiaoVienMonHocs");
        }
    }
}
