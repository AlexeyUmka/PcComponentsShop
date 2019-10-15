namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PcComponentsShop.Infrastructure.Data.Contexts.PcComponentsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PcComponentsShop.Infrastructure.Data.Contexts.PcComponentsContext";
        }

        protected override void Seed(PcComponentsShop.Infrastructure.Data.Contexts.PcComponentsShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
