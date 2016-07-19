namespace SiteECommerce.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recup_valentin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produits", "Idfournisseur", "dbo.Fournisseurs");
            DropIndex("dbo.Produits", new[] { "Idfournisseur" });
            CreateTable(
                "dbo.FournisseurProduits",
                c => new
                    {
                        Fournisseur_Idfournisseur = c.Int(nullable: false),
                        Produit_IdProduit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fournisseur_Idfournisseur, t.Produit_IdProduit })
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_Idfournisseur, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.Produit_IdProduit, cascadeDelete: true)
                .Index(t => t.Fournisseur_Idfournisseur)
                .Index(t => t.Produit_IdProduit);
            
            DropColumn("dbo.Produits", "Idfournisseur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produits", "Idfournisseur", c => c.Int(nullable: false));
            DropForeignKey("dbo.FournisseurProduits", "Produit_IdProduit", "dbo.Produits");
            DropForeignKey("dbo.FournisseurProduits", "Fournisseur_Idfournisseur", "dbo.Fournisseurs");
            DropIndex("dbo.FournisseurProduits", new[] { "Produit_IdProduit" });
            DropIndex("dbo.FournisseurProduits", new[] { "Fournisseur_Idfournisseur" });
            DropTable("dbo.FournisseurProduits");
            CreateIndex("dbo.Produits", "Idfournisseur");
            AddForeignKey("dbo.Produits", "Idfournisseur", "dbo.Fournisseurs", "Idfournisseur", cascadeDelete: true);
        }
    }
}
