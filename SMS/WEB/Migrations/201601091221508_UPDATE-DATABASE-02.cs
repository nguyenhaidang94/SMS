namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE02 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CT_QuyetDinhKhenThuong", "MaQuyetDinh");
            CreateIndex("dbo.CT_QuyetDinhKyLuat", "MaQuyetDinh");
            AddForeignKey("dbo.CT_QuyetDinhKhenThuong", "MaQuyetDinh", "dbo.QuyetDinhKhenThuong", "MaQuyetDinh");
            AddForeignKey("dbo.CT_QuyetDinhKyLuat", "MaQuyetDinh", "dbo.QuyetDinhKyLuat", "MaQuyetDinh");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CT_QuyetDinhKyLuat", "MaQuyetDinh", "dbo.QuyetDinhKyLuat");
            DropForeignKey("dbo.CT_QuyetDinhKhenThuong", "MaQuyetDinh", "dbo.QuyetDinhKhenThuong");
            DropIndex("dbo.CT_QuyetDinhKyLuat", new[] { "MaQuyetDinh" });
            DropIndex("dbo.CT_QuyetDinhKhenThuong", new[] { "MaQuyetDinh" });
        }
    }
}
