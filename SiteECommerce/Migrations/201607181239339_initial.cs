namespace SiteECommerce.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategorie = c.Int(nullable: false, identity: true),
                        NomCategorie = c.String(),
                    })
                .PrimaryKey(t => t.IdCategorie);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        IdProduit = c.Int(nullable: false, identity: true),
                        NomProduit = c.String(),
                        ImgProduit = c.String(),
                        PrixProduit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DescriptionProduit = c.String(),
                        Quantite = c.Int(nullable: false),
                        IdMarque = c.Int(nullable: false),
                        IdCategorie = c.Int(nullable: false),
                        Idfournisseur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduit)
                .ForeignKey("dbo.Categories", t => t.IdCategorie, cascadeDelete: true)
                .ForeignKey("dbo.Fournisseurs", t => t.Idfournisseur, cascadeDelete: true)
                .ForeignKey("dbo.Marques", t => t.IdMarque, cascadeDelete: true)
                .Index(t => t.IdMarque)
                .Index(t => t.IdCategorie)
                .Index(t => t.Idfournisseur);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        PrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdClient = c.Int(nullable: false),
                        MoyenPaiement = c.String(),
                        PaiementValid = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .Index(t => t.IdClient)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(nullable: false),
                        Nom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AdresseLivraison = c.String(),
                        AdresseFacturation = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.Int(nullable: false),
                        Texte = c.String(),
                        IdClient = c.Int(nullable: false),
                        IdProduit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.IdProduit, cascadeDelete: true)
                .Index(t => t.IdClient)
                .Index(t => t.IdProduit);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Idfournisseur = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.Idfournisseur);
            
            CreateTable(
                "dbo.Marques",
                c => new
                    {
                        IdMarque = c.Int(nullable: false, identity: true),
                        NomMarque = c.String(),
                    })
                .PrimaryKey(t => t.IdMarque);
            
            CreateTable(
                "dbo.CommandeProduits",
                c => new
                    {
                        Commande_Id = c.Int(nullable: false),
                        Produit_IdProduit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Commande_Id, t.Produit_IdProduit })
                .ForeignKey("dbo.Commandes", t => t.Commande_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.Produit_IdProduit, cascadeDelete: true)
                .Index(t => t.Commande_Id)
                .Index(t => t.Produit_IdProduit);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "IdMarque", "dbo.Marques");
            DropForeignKey("dbo.Produits", "Idfournisseur", "dbo.Fournisseurs");
            DropForeignKey("dbo.CommandeProduits", "Produit_IdProduit", "dbo.Produits");
            DropForeignKey("dbo.CommandeProduits", "Commande_Id", "dbo.Commandes");
            DropForeignKey("dbo.Commandes", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Commandes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Commentaires", "IdProduit", "dbo.Produits");
            DropForeignKey("dbo.Commentaires", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Produits", "IdCategorie", "dbo.Categories");
            DropIndex("dbo.CommandeProduits", new[] { "Produit_IdProduit" });
            DropIndex("dbo.CommandeProduits", new[] { "Commande_Id" });
            DropIndex("dbo.Commentaires", new[] { "IdProduit" });
            DropIndex("dbo.Commentaires", new[] { "IdClient" });
            DropIndex("dbo.Commandes", new[] { "Client_Id" });
            DropIndex("dbo.Commandes", new[] { "IdClient" });
            DropIndex("dbo.Produits", new[] { "Idfournisseur" });
            DropIndex("dbo.Produits", new[] { "IdCategorie" });
            DropIndex("dbo.Produits", new[] { "IdMarque" });
            DropTable("dbo.CommandeProduits");
            DropTable("dbo.Marques");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Clients");
            DropTable("dbo.Commandes");
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
