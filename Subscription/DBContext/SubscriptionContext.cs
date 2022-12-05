using Microsoft.EntityFrameworkCore;

namespace Subscription.DBContext
{
    public class SubscriptionContext : DbContext
    {
        public DbSet<Subscription.Model.Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=172.29.0.1,1433;" +
                $"Database=LibrarySubscription;" +
                $"User Id =dba;" +
                $"Password=Sungard%1;" +
                $"MultipleActiveResultSets=true;" +
                $"ConnectRetryCount=0;" +
                $"TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
