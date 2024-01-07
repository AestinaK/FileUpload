using FileRecord.Models;
using Microsoft.EntityFrameworkCore;

namespace FileRecord.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
    }
}
