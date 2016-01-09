namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDATABASE01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh", "dbo.QuyetDinhKhenThuong");
            DropForeignKey("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh", "dbo.QuyetDinhKyLuat");
            DropIndex("dbo.CT_QuyetDinhKhenThuong", new[] { "SoQuyetDinh" });
            DropIndex("dbo.CT_QuyetDinhKyLuat", new[] { "SoQuyetDinh" });
            DropPrimaryKey("dbo.CT_QuyetDinhKhenThuong");
            DropPrimaryKey("dbo.QuyetDinhKhenThuong");
            DropPrimaryKey("dbo.QuyetDinhKyLuat");
            DropPrimaryKey("dbo.CT_QuyetDinhKyLuat");
            AddColumn("dbo.CT_QuyetDinhKhenThuong", "MaQuyetDinh", c => c.Int(nullable: false));
            AddColumn("dbo.QuyetDinhKhenThuong", "MaQuyetDinh", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.QuyetDinhKyLuat", "MaQuyetDinh", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CT_QuyetDinhKyLuat", "MaQuyetDinh", c => c.Int(nullable: false));
            AlterColumn("dbo.QuyetDinhKhenThuong", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.QuyetDinhKyLuat", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 4000));
            AddPrimaryKey("dbo.CT_QuyetDinhKhenThuong", new[] { "MaQuyetDinh", "MaHocSinh" });
            AddPrimaryKey("dbo.QuyetDinhKhenThuong", "MaQuyetDinh");
            AddPrimaryKey("dbo.QuyetDinhKyLuat", "MaQuyetDinh");
            AddPrimaryKey("dbo.CT_QuyetDinhKyLuat", new[] { "MaQuyetDinh", "MaHocSinh" });
            DropColumn("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh");
            DropColumn("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropPrimaryKey("dbo.CT_QuyetDinhKyLuat");
            DropPrimaryKey("dbo.QuyetDinhKyLuat");
            DropPrimaryKey("dbo.QuyetDinhKhenThuong");
            DropPrimaryKey("dbo.CT_QuyetDinhKhenThuong");
            AlterColumn("dbo.QuyetDinhKyLuat", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.QuyetDinhKhenThuong", "SoQuyetDinh", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.CT_QuyetDinhKyLuat", "MaQuyetDinh");
            DropColumn("dbo.QuyetDinhKyLuat", "MaQuyetDinh");
            DropColumn("dbo.QuyetDinhKhenThuong", "MaQuyetDinh");
            DropColumn("dbo.CT_QuyetDinhKhenThuong", "MaQuyetDinh");
            AddPrimaryKey("dbo.CT_QuyetDinhKyLuat", new[] { "SoQuyetDinh", "MaHocSinh" });
            AddPrimaryKey("dbo.QuyetDinhKyLuat", "SoQuyetDinh");
            AddPrimaryKey("dbo.QuyetDinhKhenThuong", "SoQuyetDinh");
            AddPrimaryKey("dbo.CT_QuyetDinhKhenThuong", new[] { "SoQuyetDinh", "MaHocSinh" });
            CreateIndex("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh");
            CreateIndex("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh");
            AddForeignKey("dbo.CT_QuyetDinhKyLuat", "SoQuyetDinh", "dbo.QuyetDinhKyLuat", "SoQuyetDinh");
            AddForeignKey("dbo.CT_QuyetDinhKhenThuong", "SoQuyetDinh", "dbo.QuyetDinhKhenThuong", "SoQuyetDinh");
        }
    }
}
