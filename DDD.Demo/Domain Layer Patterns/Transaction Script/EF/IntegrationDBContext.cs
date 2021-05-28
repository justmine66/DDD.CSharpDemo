using System.Data.Entity;

namespace DDD.Demo.Transaction_Script.EF
{
    public class IntegrationDBContext : DbContext
    {
        public IntegrationDBContext() : base("server=.;User Id=sa;password=1;database=DDD.TS.DB;")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IntegrationDBContext>());
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RevenueRecognition> RevenueRecognitions { get; set; }

    }
}
