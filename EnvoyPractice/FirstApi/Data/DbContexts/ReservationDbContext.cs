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


    }
}
