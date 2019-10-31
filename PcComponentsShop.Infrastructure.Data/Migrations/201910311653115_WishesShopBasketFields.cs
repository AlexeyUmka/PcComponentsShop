namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishesShopBasketFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GoodsInBasket", c => c.String());
            AddColumn("dbo.AspNetUsers", "GoodsWishes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GoodsWishes");
            DropColumn("dbo.AspNetUsers", "GoodsInBasket");
        }
    }
}
