namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneNoToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PhoneNumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PhoneNumber");
        }
    }
}
