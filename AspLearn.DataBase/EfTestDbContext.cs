using AspLearn.Common.Heloers;
using AspLearn.Data.Entities;
using AspLearn.Data.Models;
using AspLearn.DataBase.MapConfigurations;
using AspLearn.DataBase.TableMaps;
using Microsoft.EntityFrameworkCore;

namespace AspLearn.DataBase {
    public class EfTestDbContext : DbContext {
        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<PointOfInterest> PointOfInterests { get; set; }

        public EfTestDbContext() {
        }

        public EfTestDbContext(DbContextOptions<EfTestDbContext> optionsBuilder) : base(optionsBuilder) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConfigurationManager.LocalAspLearnDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.AddConfiguration(new CityMap());
            modelBuilder.AddConfiguration(new PointOfInterestMap());
        }
    }
}
