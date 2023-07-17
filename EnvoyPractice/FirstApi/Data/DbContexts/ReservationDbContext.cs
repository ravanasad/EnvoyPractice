using FirstApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data.DbContexts
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Reservation>()
                .ToTable("FULLNAME")
                .Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .ToTable("EMAIL")
                .Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .ToTable("MESSAGE")
                .Property(e => e.Message)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
