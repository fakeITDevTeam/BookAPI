using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer();
        //}

        public DbSet<Book> Books { get; set; }
    }
}
