namespace AVC.DB.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Nidcategory = c.Int(nullable: false, identity: true),
                        Cnamecategory = c.String(),
                    })
                .PrimaryKey(t => t.Nidcategory);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Nidproduct = c.Int(nullable: false, identity: true),
                        Cname = c.String(),
                        Ncode = c.String(),
                        Carticul = c.String(),
                        Nexist = c.Int(nullable: false),
                        Nprice_d = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nprice_u = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ngaranty = c.Int(nullable: false),
                        Nid_category = c.Int(nullable: false),
                        Vendor = c.String(),
                        Model = c.String(),
                        Group = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        Ddateupdate = c.DateTime(nullable: false),
                        Category_Nidcategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nidproduct)
                .ForeignKey("dbo.Category", t => t.Category_Nidcategory)
                .Index(t => t.Category_Nidcategory);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Nidcategory", "dbo.Category");
            DropIndex("dbo.Products", new[] { "Category_Nidcategory" });
            DropTable("dbo.Products");
            DropTable("dbo.Category");
        }
    }
}
