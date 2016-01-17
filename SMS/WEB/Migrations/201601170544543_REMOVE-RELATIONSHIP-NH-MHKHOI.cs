namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class REMOVERELATIONSHIPNHMHKHOI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonHocKhoi", "MaNamHoc", "dbo.NamHoc");
            DropIndex("dbo.MonHocKhoi", new[] { "MaNamHoc" });
            DropPrimaryKey("dbo.MonHocKhoi");
            AddPrimaryKey("dbo.MonHocKhoi", new[] { "MaKhoi", "MaMonHoc" });
            DropColumn("dbo.MonHocKhoi", "MaNamHoc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MonHocKhoi", "MaNamHoc", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.MonHocKhoi");
            AddPrimaryKey("dbo.MonHocKhoi", new[] { "MaNamHoc", "MaKhoi", "MaMonHoc" });
            CreateIndex("dbo.MonHocKhoi", "MaNamHoc");
            AddForeignKey("dbo.MonHocKhoi", "MaNamHoc", "dbo.NamHoc", "MaNamHoc");
        }
    }
}
