namespace HAMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        participantId = c.Guid(nullable: false),
                        firstName = c.String(),
                        lastName = c.String(),
                        dob = c.DateTime(nullable: false),
                        gender = c.String(),
                        enrollmentDate = c.DateTime(nullable: false),
                        activated = c.Boolean(nullable: false),
                        activationCode = c.String(),
                        secretQuestion = c.String(),
                        secretAnswer = c.String(),
                        authCode = c.String(),
                        authorized = c.Boolean(),
                        deviceID = c.Guid(),
                    })
                .PrimaryKey(t => t.participantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Participants");
        }
    }
}
