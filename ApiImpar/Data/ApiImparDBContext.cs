using ApiImpar.Data.Map;
using ApiImpar.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiImpar.Data
{
    public class ApiImparDBContext: DbContext
    {
        public ApiImparDBContext(DbContextOptions<ApiImparDBContext>options):base(options)
        {
            
        }

        public DbSet<CarModel> Cars { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
