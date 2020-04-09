namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marketi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Markets", "NedeljaKrajRadnogVremena", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Markets", "NedeljaKrajRadnogVremena");
        }
    }
}
