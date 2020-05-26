namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelRadnaVremena : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DnevniPlans", "TipRada");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DnevniPlans", "TipRada", c => c.Byte(nullable: false));
        }
    }
}
