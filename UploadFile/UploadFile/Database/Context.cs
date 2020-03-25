using Microsoft.EntityFrameworkCore;
using UploadFile.Models;

namespace UploadFile.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AppFile> File { get; set; }
    }
}
