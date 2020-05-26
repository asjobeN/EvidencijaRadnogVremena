namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusinessActions", "TipRada", c => c.Byte(nullable: false));
            AlterColumn("dbo.DnevniPlans", "TipRada", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DnevniPlans", "TipRada", c => c.Int(nullable: false));
            AlterColumn("dbo.BusinessActions", "TipRada", c => c.Int(nullable: false));
        }
    }
}
