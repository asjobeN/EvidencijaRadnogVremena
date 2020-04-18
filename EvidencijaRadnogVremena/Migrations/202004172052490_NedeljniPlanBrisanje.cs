namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NedeljniPlanBrisanje : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NedeljniPlans", "NedeljniPlan_NedeljniPlanId", "dbo.NedeljniPlans");
            DropIndex("dbo.NedeljniPlans", new[] { "NedeljniPlan_NedeljniPlanId" });
            DropColumn("dbo.NedeljniPlans", "NedeljniPlan_NedeljniPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NedeljniPlans", "NedeljniPlan_NedeljniPlanId", c => c.Int());
            CreateIndex("dbo.NedeljniPlans", "NedeljniPlan_NedeljniPlanId");
            AddForeignKey("dbo.NedeljniPlans", "NedeljniPlan_NedeljniPlanId", "dbo.NedeljniPlans", "NedeljniPlanId");
        }
    }
}
