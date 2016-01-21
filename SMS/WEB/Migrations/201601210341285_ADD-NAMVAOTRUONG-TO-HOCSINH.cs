namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDNAMVAOTRUONGTOHOCSINH : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HocSinh", "NgayVaoTruong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HocSinh", "NgayVaoTruong", c => c.DateTime(nullable: false));
        }
    }
}
