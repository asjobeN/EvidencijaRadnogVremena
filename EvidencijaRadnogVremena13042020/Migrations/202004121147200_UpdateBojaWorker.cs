namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBojaWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "Argb", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Argb");
        }
    }
}
