namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuyetDinhKyLuat", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.QuyetDinhKhenThuong", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.QuyetDinhKyLuat", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuyetDinhKyLuat", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.QuyetDinhKhenThuong", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 4000));
            DropColumn("dbo.QuyetDinhKyLuat", "Active");
        }
    }
}
