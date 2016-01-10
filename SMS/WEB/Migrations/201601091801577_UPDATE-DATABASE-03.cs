namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE03 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CT_QuyetDinhKhenThuong", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CT_QuyetDinhKhenThuong", "Active");
        }
    }
}
