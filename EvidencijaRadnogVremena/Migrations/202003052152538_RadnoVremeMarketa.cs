namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RadnoVremeMarketa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RadnoVremeMarketas",
                c => new
                    {
                        RadnoVremeMarketaId = c.Int(nullable: false, identity: true),
                        MarketId = c.Int(nullable: false),
                        DanUNedelji = c.Int(nullable: false),
                        PocetakRadnogVremena = c.DateTime(nullable: false),
                        KrajRadnogVremena = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RadnoVremeMarketaId)
                .ForeignKey("dbo.Markets", t => t.MarketId, cascadeDelete: true)
                .Index(t => t.MarketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RadnoVremeMarketas", "MarketId", "dbo.Markets");
            DropIndex("dbo.RadnoVremeMarketas", new[] { "MarketId" });
            DropTable("dbo.RadnoVremeMarketas");
        }
    }
}
