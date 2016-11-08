using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFrameworkBasedService.Context.Migrations;
using NLog;

namespace EntityFrameworkBasedService.Context
{
    public static class PaymentsDbContextInitializer
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static readonly object lockObject = new object();
        private static bool isInitialized = false;

        public static void Initialize()
        {
            if (isInitialized) return;
            Log.Debug("Initializing database");

            lock (lockObject)
            {
                if (isInitialized) return;
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaymentsDbContext, MigrationsConfiguration>());

                var dbContext = ((IDbContextFactory<PaymentsDbContext>)new PaymentsContextFactory()).Create();
                dbContext.Database.Initialize(false);
                dbContext.Dispose();

                isInitialized = true;
                Log.Debug("Database successfully initialized");
            }
        }

        class PaymentsContextFactory : IDbContextFactory<PaymentsDbContext>
        {
            PaymentsDbContext IDbContextFactory<PaymentsDbContext>.Create()
            {
                return new PaymentsDbContext();
            }
        }
    }
}
