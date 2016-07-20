namespace SiteECommerce.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Commandes", "IdClient", "dbo.Clients");
            DropIndex("dbo.Commandes", new[] { "IdClient" });
            AlterColumn("dbo.Commandes", "IdClient", c => c.Int(nullable: false));
            CreateIndex("dbo.Commandes", "IdClient");
            AddForeignKey("dbo.Commandes", "IdClient", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commandes", "IdClient", "dbo.Clients");
            DropIndex("dbo.Commandes", new[] { "IdClient" });
            AlterColumn("dbo.Commandes", "IdClient", c => c.Int());
            CreateIndex("dbo.Commandes", "IdClient");
            AddForeignKey("dbo.Commandes", "IdClient", "dbo.Clients", "Id");
        }
    }
}
