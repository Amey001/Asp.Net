using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalManagement.Data
{
    public class MyDbContext:DbContext
    {
        public DbSet<Hospital> hospitals { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                /*.Entity<Hospital>()
                .Property(c => c.hospitaltype)
                .HasConversion(new EnumToStringConverter<Types>());*/
                .Entity<Hospital>()
                .Property(p => p.hospitaltype)
                .HasConversion(new EnumToStringConverter<Types>());
        }
    }   
}
