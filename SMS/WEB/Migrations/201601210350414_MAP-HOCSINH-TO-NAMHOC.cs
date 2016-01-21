namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAPHOCSINHTONAMHOC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HocSinh", "MaNamVaoTruong", c => c.Int(nullable: true));
            CreateIndex("dbo.HocSinh", "MaNamVaoTruong");
            AddForeignKey("dbo.HocSinh", "MaNamVaoTruong", "dbo.NamHoc", "MaNamHoc");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HocSinh", "MaNamVaoTruong", "dbo.NamHoc");
            DropIndex("dbo.HocSinh", new[] { "MaNamVaoTruong" });
            DropColumn("dbo.HocSinh", "MaNamVaoTruong");
        }
    }
}
