﻿namespace EvidencijaRadnogVremena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessActions",
                c => new
                    {
                        BusinessActionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        RadnikId = c.Int(nullable: false),
                        TipRada = c.Int(nullable: false),
                        LocalMachine = c.String(),
                    })
                .PrimaryKey(t => t.BusinessActionId)
                .ForeignKey("dbo.Workers", t => t.RadnikId, cascadeDelete: true)
                .Index(t => t.RadnikId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        RadnikId = c.Int(nullable: false, identity: true),
                        SifraRadnika = c.String(),
                        ImePrezime = c.String(),
                        Username = c.String(),
                        Password = c.String(nullable: false, maxLength: 100),
                        MarketId = c.Int(),
                        Uloga = c.Int(nullable: false),
                        Email = c.String(),
                        Pasivan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RadnikId)
                .ForeignKey("dbo.Markets", t => t.MarketId)
                .Index(t => t.MarketId);
            
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        MarketId = c.Int(nullable: false, identity: true),
                        SifraMarketa = c.String(nullable: false),
                        Adresa = c.String(nullable: false),
                        Naziv = c.String(nullable: false),
                        PonedeljakPocetakRadnogVremena = c.Time(nullable: false, precision: 7),
                        PonedeljakKrajRadnogVremena = c.Time(nullable: false, precision: 7),
                        UtorakPocetakRadnogVremena = c.Time(nullable: false, precision: 7),
                        UtorakKrajRadnogVremena = c.Time(nullable: false, precision: 7),
                        SredaPocetakRadnogVremena = c.Time(nullable: false, precision: 7),
                        SredaKrajRadnogVremena = c.Time(nullable: false, precision: 7),
                        CetvrtakPocetakRadnogVremena = c.Time(nullable: false, precision: 7),
                        CetvrtakKrajRadnogVremena = c.Time(nullable: false, precision: 7),
                        PetakPocetakRadnogVremena = c.Time(nullable: false, precision: 7),
                        PetakKrajRadnogVremena = c.Time(nullable: false, precision: 7),
                        SubotaPocetakRadnogVremena = c.Time(precision: 7),
                        SubotaKrajRadnogVremena = c.Time(precision: 7),
                        NedeljaPocetakRadnogVremena = c.Time(precision: 7),
                        NedeljaKrajRadnogVremena = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.MarketId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BusinessActions", "RadnikId", "dbo.Workers");
            DropForeignKey("dbo.Workers", "MarketId", "dbo.Markets");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Workers", new[] { "MarketId" });
            DropIndex("dbo.BusinessActions", new[] { "RadnikId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Markets");
            DropTable("dbo.Workers");
            DropTable("dbo.BusinessActions");
        }
    }
}
