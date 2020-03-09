namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promeneModela : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Markets");
            CreateTable(
                "dbo.Radniks",
                c => new
                    {
                        RadnikId = c.Int(nullable: false, identity: true),
                        SifraRadnika = c.String(),
                        ImePrezime = c.String(),
                        MarketId = c.Int(nullable: false),
                        Uloga = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RadnikId)
                .ForeignKey("dbo.Markets", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.MarketId);
            
            AddColumn("dbo.Markets", "MarketId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Markets", "SifraMarketa", c => c.String());
            AddPrimaryKey("dbo.Markets", "MarketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Radniks", "MarketId", "dbo.Markets");
            DropIndex("dbo.Radniks", new[] { "MarketId" });
            DropPrimaryKey("dbo.Markets");
            AlterColumn("dbo.Markets", "SifraMarketa", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Markets", "MarketId");
            DropTable("dbo.Radniks");
            AddPrimaryKey("dbo.Markets", "SifraMarketa");
        }
    }
}
