namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessActions",
                c => new
                    {
                        BusinessActionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        TipRada = c.Int(nullable: false),
                        LocalMachine = c.String(),
                    })
                .PrimaryKey(t => t.BusinessActionId)
                .ForeignKey("dbo.Radniks", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessActions", "RadnikId", "dbo.Radniks");
            DropIndex("dbo.BusinessActions", new[] { "RadnikId" });
            DropTable("dbo.BusinessActions");
        }
    }
}
