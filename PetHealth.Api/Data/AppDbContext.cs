using Microsoft.EntityFrameworkCore;
using PetHealth.Api.Models.Domain;

namespace PetHealth.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Role")
                .HasValue<User>("Admin")
                .HasValue<User>("User");

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Veterinarian)
                .WithMany()
                .HasForeignKey(v => v.VeterinarianId);

            modelBuilder.Entity<Visit>()
                .HasOne(v => v.Pet)
                .WithMany()
                .HasForeignKey(v => v.PetId);
        }
    }
}
