namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRelEmpDept : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Fk_DepartmentId" });
            AlterColumn("dbo.Employees", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "Fk_DepartmentId");
            AddForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Fk_DepartmentId" });
            AlterColumn("dbo.Employees", "Fk_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "Fk_DepartmentId");
            AddForeignKey("dbo.Employees", "Fk_DepartmentId", "dbo.Departments", "Id");
        }
    }
}
