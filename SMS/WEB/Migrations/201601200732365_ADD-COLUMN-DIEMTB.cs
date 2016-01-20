namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDCOLUMNDIEMTB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BangDiemHKMH", "DiemTB", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BangDiemHKMH", "DiemTB");
        }
    }
}
