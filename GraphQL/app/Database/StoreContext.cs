using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Database {
    public class StoreContext : DbContext {
        public StoreContext (DbContextOptions<StoreContext> options) : base (options) { }
        public StoreContext() { }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BooksDb");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}