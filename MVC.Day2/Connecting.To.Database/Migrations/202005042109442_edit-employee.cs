namespace Connecting.To.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editemployee : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "Employee");
            AlterColumn("dbo.Employee", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Name", c => c.String());
            RenameTable(name: "dbo.Employee", newName: "Employees");
        }
    }
}
