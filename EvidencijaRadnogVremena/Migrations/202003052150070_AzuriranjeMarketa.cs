namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AzuriranjeMarketa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Markets", "Napomena");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Markets", "Napomena", c => c.String());
        }
    }
}
