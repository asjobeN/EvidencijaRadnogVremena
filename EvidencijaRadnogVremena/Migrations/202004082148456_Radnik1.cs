namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Radnik1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Radniks", "MarketId", "dbo.Markets");
            DropIndex("dbo.Radniks", new[] { "MarketId" });
            AlterColumn("dbo.Radniks", "MarketId", c => c.Int());
            CreateIndex("dbo.Radniks", "MarketId");
            AddForeignKey("dbo.Radniks", "MarketId", "dbo.Markets", "MarketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Radniks", "MarketId", "dbo.Markets");
            DropIndex("dbo.Radniks", new[] { "MarketId" });
            AlterColumn("dbo.Radniks", "MarketId", c => c.Int(nullable: false));
            CreateIndex("dbo.Radniks", "MarketId");
            AddForeignKey("dbo.Radniks", "MarketId", "dbo.Markets", "MarketId", cascadeDelete: true);
        }
    }
}
