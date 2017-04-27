namespace GradeSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertInitialData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserAccount", "UserRole", c => c.String());
            DropColumn("dbo.UserAccount", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccount", "Salt", c => c.String());
            DropColumn("dbo.UserAccount", "UserRole");
            DropTable("dbo.Role");
        }
    }
}
