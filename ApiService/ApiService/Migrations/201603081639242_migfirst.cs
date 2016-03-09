namespace ApiService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migfirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 150, storeType: "nvarchar"),
                        description = c.String(maxLength: 150, storeType: "nvarchar"),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Products");
        }
    }
}
