namespace HAMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HVrecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "HVPersonId", c => c.Guid());
            AddColumn("dbo.Participants", "HVRecordId", c => c.Guid());
            AddColumn("dbo.Participants", "NestDeviceId", c => c.Guid());
            AddColumn("dbo.Participants", "NestAuthCode", c => c.String());
            AddColumn("dbo.Participants", "NestAuthorized", c => c.Boolean());
            DropColumn("dbo.Participants", "authCode");
            DropColumn("dbo.Participants", "authorized");
            DropColumn("dbo.Participants", "deviceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "deviceID", c => c.Guid());
            AddColumn("dbo.Participants", "authorized", c => c.Boolean());
            AddColumn("dbo.Participants", "authCode", c => c.String());
            DropColumn("dbo.Participants", "NestAuthorized");
            DropColumn("dbo.Participants", "NestAuthCode");
            DropColumn("dbo.Participants", "NestDeviceId");
            DropColumn("dbo.Participants", "HVRecordId");
            DropColumn("dbo.Participants", "HVPersonId");
        }
    }
}
