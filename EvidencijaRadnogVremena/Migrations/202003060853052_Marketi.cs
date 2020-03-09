namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marketi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        MarketId = c.Int(nullable: false, identity: true),
                        SifraMarketa = c.String(),
                        Adresa = c.String(),
                        Naziv = c.String(),
                        PonedeljakPocetakRadnogVremena = c.DateTime(nullable: false),
                        PonedeljakKrajRadnogVremena = c.DateTime(nullable: false),
                        UtorakPocetakRadnogVremena = c.DateTime(nullable: false),
                        UtorakKrajRadnogVremena = c.DateTime(nullable: false),
                        SredaPocetakRadnogVremena = c.DateTime(nullable: false),
                        SredaKrajRadnogVremena = c.DateTime(nullable: false),
                        CetvrtakPocetakRadnogVremena = c.DateTime(nullable: false),
                        CetvrtakKrajRadnogVremena = c.DateTime(nullable: false),
                        PetakPocetakRadnogVremena = c.DateTime(nullable: false),
                        PetakKrajRadnogVremena = c.DateTime(nullable: false),
                        SubotaPocetakRadnogVremena = c.DateTime(nullable: false),
                        SubotaKrajRadnogVremena = c.DateTime(nullable: false),
                        NedeljaPocetakRadnogVremena = c.DateTime(nullable: false),
                        NedeljaKrajRadnogVremena = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MarketId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Radniks", "MarketId", "dbo.Markets");
            DropIndex("dbo.Radniks", new[] { "MarketId" });
            DropTable("dbo.Radniks");
            DropTable("dbo.Markets");
        }
    }
}
