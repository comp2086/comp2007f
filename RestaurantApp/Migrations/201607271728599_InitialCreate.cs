namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appetizers",
                c => new
                    {
                        AppetizerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThumbNail = c.String(),
                        FullImage = c.String(),
                        ShortDesc = c.String(),
                        FullDesc = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AppetizerId);
            
            CreateTable(
                "dbo.Desserts",
                c => new
                    {
                        DessertId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThumbNail = c.String(),
                        FullImage = c.String(),
                        ShortDesc = c.String(),
                        FullDesc = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DessertId);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThumbNail = c.String(),
                        FullImage = c.String(),
                        ShortDesc = c.String(),
                        FullDesc = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkId);
            
            CreateTable(
                "dbo.MainCourses",
                c => new
                    {
                        MainCourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ThumbNail = c.String(),
                        FullImage = c.String(),
                        ShortDesc = c.String(),
                        FullDesc = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MainCourseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainCourses");
            DropTable("dbo.Drinks");
            DropTable("dbo.Desserts");
            DropTable("dbo.Appetizers");
        }
    }
}
