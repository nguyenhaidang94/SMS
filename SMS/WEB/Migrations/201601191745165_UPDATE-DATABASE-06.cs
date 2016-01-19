namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE06 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GiaoVienMonHocs", newName: "GiaoVienMonHoc");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GiaoVienMonHoc", newName: "GiaoVienMonHocs");
        }
    }
}
