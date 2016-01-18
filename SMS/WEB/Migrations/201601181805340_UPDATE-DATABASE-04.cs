namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE04 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CT_QuyetDinhKyLuat", "HinhThucKyLuat", c => c.String(nullable: true, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKyLuat", "LyDoKyLuat", c => c.String(nullable: true, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKhenThuong", "HinhThucKhenThuong", c => c.String(nullable: true, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKhenThuong", "LyDoKhenThuong", c => c.String(nullable: true, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CT_QuyetDinhKyLuat", "HinhThucKyLuat", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKyLuat", "LyDoKyLuat", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKhenThuong", "HinhThucKhenThuong", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.CT_QuyetDinhKhenThuong", "LyDoKhenThuong", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
