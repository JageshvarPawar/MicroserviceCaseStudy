using Book.Model;
using Microsoft.EntityFrameworkCore;

namespace Book.DBContext
{
    public class BookContext:DbContext
    {
        public DbSet<Book.Model.Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=172.29.0.1,1433;" +
                $"Database=LibraryBook;" +
                $"User Id =dba;" +
                $"Password=Sungard%1;" +
                $"MultipleActiveResultSets=true;" +
                $"ConnectRetryCount=0;"+
                $"TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
