namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAP_HOCSINH_TO_LOPHOC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThamSo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenThamSo = c.String(),
                        GiaTri = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LopHoc_HocSinh",
                c => new
                    {
                        MaHocSinh = c.Int(nullable: false),
                        MaLopHoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MaHocSinh, t.MaLopHoc })
                .ForeignKey("dbo.HocSinh", t => t.MaHocSinh, cascadeDelete: false)
                .ForeignKey("dbo.LopHoc", t => t.MaLopHoc, cascadeDelete: false)
                .Index(t => t.MaHocSinh)
                .Index(t => t.MaLopHoc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LopHoc_HocSinh", "MaLopHoc", "dbo.LopHoc");
            DropForeignKey("dbo.LopHoc_HocSinh", "MaHocSinh", "dbo.HocSinh");
            DropIndex("dbo.LopHoc_HocSinh", new[] { "MaLopHoc" });
            DropIndex("dbo.LopHoc_HocSinh", new[] { "MaHocSinh" });
            DropTable("dbo.LopHoc_HocSinh");
            DropTable("dbo.ThamSo");
        }
    }
}
