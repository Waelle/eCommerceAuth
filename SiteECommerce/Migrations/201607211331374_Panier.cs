namespace SiteECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Panier : DbMigration
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
                    })
                .PrimaryKey(t => t.IdProduit)
                .ForeignKey("dbo.Categories", t => t.IdCategorie, cascadeDelete: true)
                .ForeignKey("dbo.Marques", t => t.IdMarque, cascadeDelete: true)
                .Index(t => t.IdMarque)
                .Index(t => t.IdCategorie);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        IdCommande = c.Int(nullable: false, identity: true),
                        IdClient = c.Int(),
                        IdPanier = c.Int(),
                        MoyenPaiement = c.String(),
                        PaiementValid = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Client_Id = c.Int(),
                        Produit_IdProduit = c.Int(),
                    })
                .PrimaryKey(t => t.IdCommande)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .ForeignKey("dbo.Paniers", t => t.IdPanier)
                .ForeignKey("dbo.Produits", t => t.Produit_IdProduit)
                .Index(t => t.IdClient)
                .Index(t => t.IdPanier)
                .Index(t => t.Client_Id)
                .Index(t => t.Produit_IdProduit);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(nullable: false),
                        Nom = c.String(nullable: false),
                        AdresseLivraison = c.String(nullable: false),
                        AdresseFacturation = c.String(nullable: false),
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
                "dbo.Paniers",
                c => new
                    {
                        IdPanier = c.Int(nullable: false, identity: true),
                        QuantitePanier = c.Int(nullable: false),
                        PrixTotalPanier = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPanier);
            
            CreateTable(
                "dbo.LignePaniers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Produit_IdProduit = c.Int(),
                        Panier_IdPanier = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produits", t => t.Produit_IdProduit)
                .ForeignKey("dbo.Paniers", t => t.Panier_IdPanier)
                .Index(t => t.Produit_IdProduit)
                .Index(t => t.Panier_IdPanier);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Produits", "IdMarque", "dbo.Marques");
            DropForeignKey("dbo.FournisseurProduits", "Produit_IdProduit", "dbo.Produits");
            DropForeignKey("dbo.FournisseurProduits", "Fournisseur_Idfournisseur", "dbo.Fournisseurs");
            DropForeignKey("dbo.Commandes", "Produit_IdProduit", "dbo.Produits");
            DropForeignKey("dbo.Commandes", "IdPanier", "dbo.Paniers");
            DropForeignKey("dbo.Commandes", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Commandes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.LignePaniers", "Panier_IdPanier", "dbo.Paniers");
            DropForeignKey("dbo.LignePaniers", "Produit_IdProduit", "dbo.Produits");
            DropForeignKey("dbo.Commentaires", "IdProduit", "dbo.Produits");
            DropForeignKey("dbo.Commentaires", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Produits", "IdCategorie", "dbo.Categories");
            DropIndex("dbo.FournisseurProduits", new[] { "Produit_IdProduit" });
            DropIndex("dbo.FournisseurProduits", new[] { "Fournisseur_Idfournisseur" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LignePaniers", new[] { "Panier_IdPanier" });
            DropIndex("dbo.LignePaniers", new[] { "Produit_IdProduit" });
            DropIndex("dbo.Commentaires", new[] { "IdProduit" });
            DropIndex("dbo.Commentaires", new[] { "IdClient" });
            DropIndex("dbo.Commandes", new[] { "Produit_IdProduit" });
            DropIndex("dbo.Commandes", new[] { "Client_Id" });
            DropIndex("dbo.Commandes", new[] { "IdPanier" });
            DropIndex("dbo.Commandes", new[] { "IdClient" });
            DropIndex("dbo.Produits", new[] { "IdCategorie" });
            DropIndex("dbo.Produits", new[] { "IdMarque" });
            DropTable("dbo.FournisseurProduits");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Marques");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.LignePaniers");
            DropTable("dbo.Paniers");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Clients");
            DropTable("dbo.Commandes");
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
