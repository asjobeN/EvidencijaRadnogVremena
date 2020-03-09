namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class marketdodavanjenapomene : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Markets", "Napomena", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Markets", "Napomena");
        }
    }
}
