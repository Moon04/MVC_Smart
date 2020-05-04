namespace Connecting.To.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Address", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Address");
        }
    }
}
