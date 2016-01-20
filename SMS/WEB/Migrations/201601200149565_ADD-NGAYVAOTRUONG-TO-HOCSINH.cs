namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDNGAYVAOTRUONGTOHOCSINH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HocSinh", "NgayVaoTruong", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HocSinh", "NgayVaoTruong");
        }
    }
}
