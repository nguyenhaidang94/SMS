namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDIDMONHOCKHOI : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MonHocKhoi");
            AddColumn("dbo.MonHocKhoi", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MonHocKhoi", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MonHocKhoi");
            DropColumn("dbo.MonHocKhoi", "Id");
            AddPrimaryKey("dbo.MonHocKhoi", new[] { "MaKhoi", "MaMonHoc" });
        }
    }
}
