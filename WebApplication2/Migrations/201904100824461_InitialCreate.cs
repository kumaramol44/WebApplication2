namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Age = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Gender = c.Byte(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        ProfileImage = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 150, unicode: false),
                        WorkContact = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Mobile = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subjects = c.String(maxLength: 50),
                        EmployeeId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpSubjects", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmpSubjects", new[] { "EmployeeId" });
            DropTable("dbo.EmpSubjects");
            DropTable("dbo.Employee");
        }
    }
}
