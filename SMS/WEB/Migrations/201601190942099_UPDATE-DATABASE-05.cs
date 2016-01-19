namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE05 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CT_QuyetDinhKhenThuong");
            DropPrimaryKey("dbo.CT_QuyetDinhKyLuat");
            AddColumn("dbo.CT_QuyetDinhKhenThuong", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CT_QuyetDinhKyLuat", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CT_QuyetDinhKhenThuong", "Id");
            AddPrimaryKey("dbo.CT_QuyetDinhKyLuat", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CT_QuyetDinhKyLuat");
            DropPrimaryKey("dbo.CT_QuyetDinhKhenThuong");
            DropColumn("dbo.CT_QuyetDinhKyLuat", "Id");
            DropColumn("dbo.CT_QuyetDinhKhenThuong", "Id");
            AddPrimaryKey("dbo.CT_QuyetDinhKyLuat", new[] { "MaQuyetDinh", "MaHocSinh" });
            AddPrimaryKey("dbo.CT_QuyetDinhKhenThuong", new[] { "MaQuyetDinh", "MaHocSinh" });
        }
    }
}
