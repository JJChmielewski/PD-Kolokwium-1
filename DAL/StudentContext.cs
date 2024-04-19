using Microsoft.EntityFrameworkCore;
using PD_Kolokwium_1.Models;

namespace DAL
{
    public class StudentContext : DbContext
    {

        public DbSet<Student> students {  get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<History> history { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany()
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Group)
                .WithMany()
                .HasForeignKey(h => h.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
