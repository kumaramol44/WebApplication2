namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationForRoleInEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Designation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Designation");
        }
    }
}
