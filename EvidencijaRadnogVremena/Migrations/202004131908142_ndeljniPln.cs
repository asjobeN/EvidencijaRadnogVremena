namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ndeljniPln : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NedeljniPlans",
                c => new
                    {
                        NedeljniPlanId = c.Int(nullable: false, identity: true),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        MarketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NedeljniPlanId);
            
            CreateTable(
                "dbo.DnevniPlans",
                c => new
                    {
                        DnevniPlanId = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        NedeljniPlanId = c.Int(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        IdZamenskogRadnika = c.Int(nullable: false),
                        PlaniranPocetakRada = c.DateTime(nullable: false),
                        PlaniranKrajRada = c.DateTime(nullable: false),
                        TipRada = c.Int(nullable: false),
                        PlaniranPocetakPauze = c.DateTime(nullable: false),
                        PlaniranKrajPauze = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DnevniPlanId)
                .ForeignKey("dbo.NedeljniPlans", t => t.NedeljniPlanId, cascadeDelete: true)
                .Index(t => t.NedeljniPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DnevniPlans", "NedeljniPlanId", "dbo.NedeljniPlans");
            DropIndex("dbo.DnevniPlans", new[] { "NedeljniPlanId" });
            DropTable("dbo.DnevniPlans");
            DropTable("dbo.NedeljniPlans");
        }
    }
}
