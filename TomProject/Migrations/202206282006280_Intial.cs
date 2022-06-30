namespace TomProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExportRecipets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Type = c.String(),
                        Size = c.Int(nullable: false),
                        FillQuantity = c.Int(nullable: false),
                        NumberOfUnit = c.Int(nullable: false),
                        UnitWeight = c.Single(nullable: false),
                        TotalWeight = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_ID = c.Int(),
                        FillItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .ForeignKey("dbo.FillItems", t => t.FillItem_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.FillItem_ID);
            
            CreateTable(
                "dbo.FillItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FillRecipets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Notes = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FillItem_ID = c.Int(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FillItems", t => t.FillItem_ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.FillItem_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.harvestedRecipets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Type = c.String(),
                        Size = c.Int(nullable: false),
                        FillQuantity = c.Int(nullable: false),
                        NumberOfUnit = c.Int(nullable: false),
                        UnitWeight = c.Single(nullable: false),
                        TotalWeight = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FillItem_ID = c.Int(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FillItems", t => t.FillItem_ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.FillItem_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.RawRecipets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Type = c.String(),
                        Size = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        FinalWeight = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.SupplierTransactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionType = c.String(),
                        Notes = c.String(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.YeildRecipts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        CaratPrice = c.Single(nullable: false),
                        AcrePrice = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remaining = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.CustomerTransactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionType = c.String(),
                        Notes = c.String(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.WalletItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                        WalletItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WalletItems", t => t.WalletItem_ID)
                .Index(t => t.WalletItem_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "WalletItem_ID", "dbo.WalletItems");
            DropForeignKey("dbo.CustomerTransactions", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.YeildRecipts", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierTransactions", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.RawRecipets", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.harvestedRecipets", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.harvestedRecipets", "FillItem_ID", "dbo.FillItems");
            DropForeignKey("dbo.FillRecipets", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.FillRecipets", "FillItem_ID", "dbo.FillItems");
            DropForeignKey("dbo.ExportRecipets", "FillItem_ID", "dbo.FillItems");
            DropForeignKey("dbo.ExportRecipets", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Wallets", new[] { "WalletItem_ID" });
            DropIndex("dbo.CustomerTransactions", new[] { "Customer_ID" });
            DropIndex("dbo.YeildRecipts", new[] { "Supplier_ID" });
            DropIndex("dbo.SupplierTransactions", new[] { "Supplier_ID" });
            DropIndex("dbo.RawRecipets", new[] { "Supplier_ID" });
            DropIndex("dbo.harvestedRecipets", new[] { "Supplier_ID" });
            DropIndex("dbo.harvestedRecipets", new[] { "FillItem_ID" });
            DropIndex("dbo.FillRecipets", new[] { "Supplier_ID" });
            DropIndex("dbo.FillRecipets", new[] { "FillItem_ID" });
            DropIndex("dbo.ExportRecipets", new[] { "FillItem_ID" });
            DropIndex("dbo.ExportRecipets", new[] { "Customer_ID" });
            DropTable("dbo.Wallets");
            DropTable("dbo.WalletItems");
            DropTable("dbo.CustomerTransactions");
            DropTable("dbo.YeildRecipts");
            DropTable("dbo.SupplierTransactions");
            DropTable("dbo.RawRecipets");
            DropTable("dbo.harvestedRecipets");
            DropTable("dbo.Suppliers");
            DropTable("dbo.FillRecipets");
            DropTable("dbo.FillItems");
            DropTable("dbo.ExportRecipets");
            DropTable("dbo.Customers");
        }
    }
}
