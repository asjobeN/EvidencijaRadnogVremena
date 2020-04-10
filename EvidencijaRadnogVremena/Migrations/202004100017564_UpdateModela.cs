namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModela : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Radniks", newName: "Workers");
            AddColumn("dbo.Markets", "NedeljaKrajRadnogVremena", c => c.Time(precision: 7));
            AlterColumn("dbo.Markets", "SifraMarketa", c => c.String(nullable: false));
            AlterColumn("dbo.Markets", "Adresa", c => c.String(nullable: false));
            AlterColumn("dbo.Markets", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Markets", "SubotaPocetakRadnogVremena", c => c.Time(precision: 7));
            AlterColumn("dbo.Markets", "SubotaKrajRadnogVremena", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Markets", "SubotaKrajRadnogVremena", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Markets", "SubotaPocetakRadnogVremena", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Markets", "Naziv", c => c.String());
            AlterColumn("dbo.Markets", "Adresa", c => c.String());
            AlterColumn("dbo.Markets", "SifraMarketa", c => c.String());
            DropColumn("dbo.Markets", "NedeljaKrajRadnogVremena");
            RenameTable(name: "dbo.Workers", newName: "Radniks");
        }
    }
}
