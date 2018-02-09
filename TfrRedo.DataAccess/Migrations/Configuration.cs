using System.Data.Entity.Migrations;

namespace TfrRedo.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TfrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TfrContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}