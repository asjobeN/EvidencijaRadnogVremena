namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Radnik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Radniks", "Username", c => c.String());
            AddColumn("dbo.Radniks", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Radniks", "Password");
            DropColumn("dbo.Radniks", "Username");
        }
    }
}
