using Web.Data;

namespace Web.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateReservation(CreateReservationDto request);
        Task<List<ReservationDto>> GetAllReservation();
    }
}
