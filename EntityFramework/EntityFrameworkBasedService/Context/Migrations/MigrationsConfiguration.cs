using System.Data.Entity.Migrations;

namespace EntityFrameworkBasedService.Context.Migrations
{
    class MigrationsConfiguration : DbMigrationsConfiguration<PaymentsDbContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            MigrationsDirectory = @"Context\Migrations";
            ContextKey = "AwesomePlatform.Payments.Repositories.PaymentsDbContext";
        }

        protected override void Seed(PaymentsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
