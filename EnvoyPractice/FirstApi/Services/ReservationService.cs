using FirstApi.Data.DbContexts;
using FirstApi.Data.Entities;
using FirstApi.Services.Interfaces;
using Shared.Services.EfCore;

namespace FirstApi.Services
{
    public class ReservationService : EfService<Reservation, ReservationDbContext>, IReservationService
    {
        public ReservationService(ReservationDbContext context) : base(context)
        {
        }
    }
}
