using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoService
{
    class DataService : DbContext
    {
        public DataService()
            : base("DBConnection") { }

        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<CarWash> CarWashes { get; set; }
        public DbSet<Repair> repairs { get; set; }
        public DbSet<PaintingWorks> PaintingWorks { get; set; }
        public DbSet<TireShop> TireShops { get; set; }
        public DbSet<Autoelectrics> Autoelectrics { get; set; }
        public DbSet<Motor> Motors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarService>()
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Staff>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Staffs");
            });
            modelBuilder.Entity<Service>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Services");
            });
            modelBuilder.Entity<CarWash>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CarWashes");
            });
            modelBuilder.Entity<Repair>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Repairs");
            });
            modelBuilder.Entity<PaintingWorks>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PaintingWorks");
            });
            modelBuilder.Entity<TireShop>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TireShops");
            });
            modelBuilder.Entity<Autoelectrics>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Autoelectrics");
            });
            modelBuilder.Entity<Motor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Motors");
            });
        }
    }
}
