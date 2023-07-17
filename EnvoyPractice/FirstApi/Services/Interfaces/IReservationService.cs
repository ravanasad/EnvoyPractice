using FirstApi.Data.DbContexts;
using FirstApi.Data.Entities;
using Shared.Services.EfCore;

namespace FirstApi.Services.Interfaces
{
    public interface IReservationService : IEfService<Reservation, ReservationDbContext>
    {
    }
}
