namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Objekats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Objekats",
                c => new
                    {
                        SifraObjekta = c.String(nullable: false, maxLength: 128),
                        Adresa = c.String(),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.SifraObjekta);
            
        }
    }
}
