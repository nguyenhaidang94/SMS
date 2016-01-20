namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAPMONHOCTOKHOI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonHocKhoi", "MaKhoi", "dbo.KhoiLop");
            DropForeignKey("dbo.MonHocKhoi", "MaMonHoc", "dbo.MonHoc");
            DropIndex("dbo.MonHocKhoi", new[] { "MaKhoi" });
            DropIndex("dbo.MonHocKhoi", new[] { "MaMonHoc" });
            CreateTable(
                "dbo.MonHoc_Khoi",
                c => new
                    {
                        MaKhoi = c.Int(nullable: false),
                        MaMonHoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaKhoi, t.MaMonHoc })
                .ForeignKey("dbo.KhoiLop", t => t.MaKhoi, cascadeDelete: false)
                .ForeignKey("dbo.MonHoc", t => t.MaMonHoc, cascadeDelete: false)
                .Index(t => t.MaKhoi)
                .Index(t => t.MaMonHoc);
            
            DropTable("dbo.MonHocKhoi");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MonHocKhoi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaKhoi = c.Int(nullable: false),
                        MaMonHoc = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.MonHoc_Khoi", "MaMonHoc", "dbo.MonHoc");
            DropForeignKey("dbo.MonHoc_Khoi", "MaKhoi", "dbo.KhoiLop");
            DropIndex("dbo.MonHoc_Khoi", new[] { "MaMonHoc" });
            DropIndex("dbo.MonHoc_Khoi", new[] { "MaKhoi" });
            DropTable("dbo.MonHoc_Khoi");
            CreateIndex("dbo.MonHocKhoi", "MaMonHoc");
            CreateIndex("dbo.MonHocKhoi", "MaKhoi");
            AddForeignKey("dbo.MonHocKhoi", "MaMonHoc", "dbo.MonHoc", "MaMonHoc");
            AddForeignKey("dbo.MonHocKhoi", "MaKhoi", "dbo.KhoiLop", "MaKhoi");
        }
    }
}
