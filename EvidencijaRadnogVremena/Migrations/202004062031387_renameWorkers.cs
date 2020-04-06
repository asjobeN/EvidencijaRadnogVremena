namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameWorkers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Radniks", newName: "Workers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Workers", newName: "Radniks");
        }
    }
}
